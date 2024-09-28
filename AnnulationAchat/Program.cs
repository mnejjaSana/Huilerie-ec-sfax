using AnnulationAchatHuile.Model;
using AnnulationAchatHuile.Model.Enumuration;
using AnnulationAchatHuile.Sql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AnnulationAchatHuile
{
    class Program
    {
        private static String ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["Context"].ConnectionString;
            }
        }


        static void Main(string[] args)
        {

            string CodeAchat = "";

            while (true)
            {
                Console.WriteLine("Entrez votre Code Achat Huile: ");

                CodeAchat = Console.ReadLine();

                // Add your validation condition here
                if (IsValidCodeAchat(CodeAchat))
                {
                    // Valid input, you can continue with your logic
                    Achat AchatDb = new Achat();

                    AchatDb = SqlJob.GetAchat(CodeAchat);
                    
                    if (AchatDb != null)
                    {
                        if(AchatDb.EtatAchat== EtatAchat.PartiellementReglee)
                        {
                            Console.WriteLine("Achat Partiellement réglée. Aucun traitement effectué");

                        }
                        else
                        {
                            string DateCreation = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                            AchatDb.Founisseur = SqlJob.GetFounisseur(AchatDb.Founisseur_Id);

                            AchatDb.Pile = SqlJob.GetPile(AchatDb.Pile_Id);

                            int IDAchat = AchatDb.Id;

                            string NumAvance = AchatDb.Numero.Replace("HLE", "AVN");

                            string commantaireDepense = "Avance Agriculteur_" + AchatDb.Numero.Remove(0, 3);

                            decimal totalAchatAgr = AchatDb.Founisseur.TotalAchats;

                            decimal totalAvanceAgr = AchatDb.Founisseur.TotalAvances;

                            // mode paiement espece
                            if (AchatDb.TypeAchat == TypeAchat.Huile && totalAchatAgr == totalAvanceAgr && AchatDb.ModeReglement == ModeReglement.Espèce)
                            {
                                SqlJob.UpdateMouvementStock(IDAchat);

                                SqlJob.UpdateMouvementCaisse(IDAchat);


                                #region add alimentation
                                int maxIdAlimentation = SqlJob.GetMaxIdAlimentation() + 1;
                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();

                                    using (SqlCommand cmd = new SqlCommand(SqlScript.AddAlimentation, connection))
                                    {
                                        cmd.Parameters.AddWithValue("@Numero", "E" + maxIdAlimentation.ToString("D8"));
                                        cmd.Parameters.AddWithValue("@DateCreation", Convert.ToDateTime(DateCreation));
                                        cmd.Parameters.AddWithValue("@Montant", AchatDb.MontantRegle);
                                        cmd.Parameters.AddWithValue("@Commentaire", "Annulation Achat N°" + AchatDb.Numero);

                                        cmd.CommandType = CommandType.Text;
                                        cmd.ExecuteNonQuery();
                                    }
                                }


                                #endregion

                                #region add AddMvtCaisse

                                decimal SoldeCaisseDB = SqlJob.GetSoldeCaisse();

                                decimal SoleCaisseAfterAlm = decimal.Add(SoldeCaisseDB, AchatDb.MontantRegle);


                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();

                                    using (SqlCommand cmd = new SqlCommand(SqlScript.AddMvtCaisse, connection))
                                    {

                                        cmd.Parameters.AddWithValue("@Numero", "E" + maxIdAlimentation.ToString("D8"));
                                        cmd.Parameters.AddWithValue("@DateCreation", Convert.ToDateTime(DateCreation));
                                        cmd.Parameters.AddWithValue("@Source", "Autre");
                                        cmd.Parameters.AddWithValue("@Commentaire", "Annulation Achat N° " + AchatDb.Numero);
                                        cmd.Parameters.AddWithValue("@MontantSens", AchatDb.MontantRegle);
                                        cmd.Parameters.AddWithValue("@Montant", SoleCaisseAfterAlm);


                                        cmd.CommandType = CommandType.Text;
                                        cmd.ExecuteNonQuery();
                                    }
                                }


                                #endregion


                                #region update solde caisse

                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();

                                    using (SqlCommand cmd = new SqlCommand(SqlScript.UpdateSoldeCaisse, connection))
                                    {
                                        cmd.Parameters.AddWithValue("@MontantTotal", SoleCaisseAfterAlm);

                                        cmd.CommandType = CommandType.Text;
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                                #endregion

                                #region AddMvtStockSortieDivers

                                int maxIdMouvementStock = SqlJob.GetMaxIdMouvementStock() + 1;

                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();

                                    using (SqlCommand cmd = new SqlCommand(SqlScript.AddMvtStockSortieDivers, connection))
                                    {
                                        cmd.Parameters.AddWithValue("@Numero", "SOD" + maxIdMouvementStock.ToString("D8"));
                                        cmd.Parameters.AddWithValue("@QuantiteSOD", AchatDb.QteHuileAchetee);
                                        cmd.Parameters.AddWithValue("@Commentaire", "Annulation Achat N°" + AchatDb.Numero);
                                        cmd.Parameters.AddWithValue("@Date", Convert.ToDateTime(DateCreation));
                                        cmd.Parameters.AddWithValue("@Qualite", AchatDb.Pile.article);
                                        cmd.Parameters.AddWithValue("@QuantitePileInitial", AchatDb.Pile.Capacite);
                                        cmd.Parameters.AddWithValue("@QuantitePileFinal", AchatDb.Pile.Capacite - AchatDb.QteHuileAchetee);
                                        cmd.Parameters.AddWithValue("@PrixMouvement", AchatDb.Pile.PrixMoyen);
                                        cmd.Parameters.AddWithValue("@PMP", AchatDb.Pile.PrixMoyen);
                                        cmd.Parameters.AddWithValue("@QteSortante", AchatDb.QteHuileAchetee);
                                        cmd.Parameters.AddWithValue("@pile_Id", AchatDb.Pile.Id);
                                        cmd.CommandType = CommandType.Text;
                                        cmd.ExecuteNonQuery();
                                    }
                                }


                                #endregion


                                #region update Pile

                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();

                                    using (SqlCommand cmd = new SqlCommand(SqlScript.UpdatePile, connection))
                                    {
                                        cmd.Parameters.AddWithValue("@Capacite", AchatDb.Pile.Capacite - AchatDb.QteHuileAchetee);
                                        cmd.Parameters.AddWithValue("@IdPile", AchatDb.Pile.Id);
                                        cmd.CommandType = CommandType.Text;
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                                #endregion

                                Pile PileUpdated = SqlJob.GetPile(AchatDb.Pile_Id); ;

                                // Update Prix Moyen Pile After Update Capacité
                                if (PileUpdated.Capacite == 0)
                                {
                                    SqlJob.UpdatePMPPile(PileUpdated.Id);

                                }

                                List<HistoriquePaiementAchats> ListHistAchat = SqlJob.GetListHistoriqueAchat(AchatDb.Founisseur.Id, AchatDb.Numero);

                                //    kol avance t5alas charyetha(montant achat = montant avance)
                                if (AchatDb.AvanceAvecAchat > 0 && ListHistAchat.Count == 1 && ListHistAchat[0].MontantRegle == AchatDb.AvanceAvecAchat && ListHistAchat[0].Commentaire.Equals("Règlement Automatique Par Avance") && ListHistAchat[0].MontantRegle == ListHistAchat[0].MontantReglement)
                                {
                                    SqlJob.DeleteDepense("%" + AchatDb.Numero.Remove(0, 3));

                                    SqlJob.DeleteHistoriqueAchat(AchatDb.Numero);

                                    SqlJob.DeleteAvance(NumAvance);

                                    SqlJob.DeleteAchat(IDAchat);
                                }

                                //    achat totalement reglé par caisse(à partir liste achats)
                                if (AchatDb.AvanceAvecAchat == 0 && ListHistAchat.All(obj => obj.Commentaire == ListHistAchat.First().Commentaire) && ListHistAchat[0].Commentaire.Equals("Règlement Caisse"))
                                {
                                    SqlJob.DeleteDepense("%" + AchatDb.Numero.Remove(0, 3));

                                    SqlJob.DeleteHistoriqueAchat(AchatDb.Numero);

                                    SqlJob.DeleteAchat(IDAchat);
                                }

                                //    achat totalement reglé par avance de type avance(l'avance met3ediya wa7adha mouch m3a chariya ) 
                                if (AchatDb.AvanceAvecAchat == 0 && ListHistAchat.Count == 1 && ListHistAchat[0].Commentaire.Equals("Règlement Automatique Par Avance") && ListHistAchat[0].MontantRegle == ListHistAchat[0].MontantReglement)
                                {
                                    SqlJob.DeleteDepenseAvance("Avance Agriculteur", AchatDb.Founisseur_Id, AchatDb.MontantReglement);

                                    SqlJob.DeleteHistoriqueAchat(AchatDb.Numero);

                                    Achat Avance = SqlJob.GetAvance(AchatDb.Founisseur_Id, AchatDb.MontantReglement);

                                    SqlJob.UpdateMouvementCaisse(Avance.Id);

                                    SqlJob.DeleteAchat(Avance.Id);

                                    SqlJob.DeleteAchat(IDAchat);
                                }


                                Console.WriteLine("Traitement terminé avec succès");


                            }

                            // mode paiement cheque ou traite
                            else if (AchatDb.TypeAchat == TypeAchat.Huile && totalAchatAgr == totalAvanceAgr && (AchatDb.ModeReglement == ModeReglement.Chèque || AchatDb.ModeReglement == ModeReglement.Traite))
                            {
                                SqlJob.UpdateMouvementStock(IDAchat);

                                Coffrecheque CoffreCheque = SqlJob.GetCoffreCheque(AchatDb.MontantRegle, AchatDb.NumeroCheque, AchatDb.Banque, AchatDb.DateEcheance);

                                SqlJob.DeleteCoffreCheque(CoffreCheque.Id);

                                int IdDepenseCoffre = CoffreCheque.Depense_Id;

                                SqlJob.DeleteDepenseById(IdDepenseCoffre);

                                #region AddMvtStockSortieDivers

                                int maxIdMouvementStock = SqlJob.GetMaxIdMouvementStock() + 1;

                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();

                                    using (SqlCommand cmd = new SqlCommand(SqlScript.AddMvtStockSortieDivers, connection))
                                    {
                                        cmd.Parameters.AddWithValue("@Numero", "SOD" + maxIdMouvementStock.ToString("D8"));
                                        cmd.Parameters.AddWithValue("@QuantiteSOD", AchatDb.QteHuileAchetee);
                                        cmd.Parameters.AddWithValue("@Commentaire", "Annulation Achat N°" + AchatDb.Numero);
                                        cmd.Parameters.AddWithValue("@Date", Convert.ToDateTime(DateCreation));
                                        cmd.Parameters.AddWithValue("@Qualite", AchatDb.Pile.article);
                                        cmd.Parameters.AddWithValue("@QuantitePileInitial", AchatDb.Pile.Capacite);
                                        cmd.Parameters.AddWithValue("@QuantitePileFinal", AchatDb.Pile.Capacite - AchatDb.QteHuileAchetee);
                                        cmd.Parameters.AddWithValue("@PrixMouvement", AchatDb.Pile.PrixMoyen);
                                        cmd.Parameters.AddWithValue("@PMP", AchatDb.Pile.PrixMoyen);
                                        cmd.Parameters.AddWithValue("@QteSortante", AchatDb.QteHuileAchetee);
                                        cmd.Parameters.AddWithValue("@pile_Id", AchatDb.Pile.Id);
                                        cmd.CommandType = CommandType.Text;
                                        cmd.ExecuteNonQuery();
                                    }
                                }


                                #endregion


                                #region update Pile

                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();

                                    using (SqlCommand cmd = new SqlCommand(SqlScript.UpdatePile, connection))
                                    {
                                        cmd.Parameters.AddWithValue("@Capacite", AchatDb.Pile.Capacite - AchatDb.QteHuileAchetee);
                                        cmd.Parameters.AddWithValue("@IdPile", AchatDb.Pile.Id);
                                        cmd.CommandType = CommandType.Text;
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                                #endregion

                                Pile PileUpdated = SqlJob.GetPile(AchatDb.Pile_Id); ;

                                // Update Prix Moyen Pile After Update Capacité
                                if (PileUpdated.Capacite == 0)
                                {
                                    SqlJob.UpdatePMPPile(PileUpdated.Id);

                                }

                                SqlJob.DeleteAchat(IDAchat);

                                SqlJob.DeleteAvance(NumAvance);

                                SqlJob.DeleteDepense(commantaireDepense);

                                SqlJob.DeleteHistoriqueAchat(AchatDb.Numero);

                                Console.WriteLine("Traitement terminé avec succès");
                            }

                            // non reglé
                            else if (AchatDb.TypeAchat == TypeAchat.Huile && AchatDb.EtatAchat == EtatAchat.NonReglee)
                            {
                                SqlJob.UpdateMouvementStock(IDAchat);

                                #region AddMvtStockSortieDivers

                                int maxIdMouvementStock = SqlJob.GetMaxIdMouvementStock() + 1;

                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();

                                    using (SqlCommand cmd = new SqlCommand(SqlScript.AddMvtStockSortieDivers, connection))
                                    {
                                        cmd.Parameters.AddWithValue("@Numero", "SOD" + maxIdMouvementStock.ToString("D8"));
                                        cmd.Parameters.AddWithValue("@QuantiteSOD", AchatDb.QteHuileAchetee);
                                        cmd.Parameters.AddWithValue("@Commentaire", "Annulation Achat N°" + AchatDb.Numero);
                                        cmd.Parameters.AddWithValue("@Date", Convert.ToDateTime(DateCreation));
                                        cmd.Parameters.AddWithValue("@Qualite", AchatDb.Pile.article);
                                        cmd.Parameters.AddWithValue("@QuantitePileInitial", AchatDb.Pile.Capacite);
                                        cmd.Parameters.AddWithValue("@QuantitePileFinal", AchatDb.Pile.Capacite - AchatDb.QteHuileAchetee);
                                        cmd.Parameters.AddWithValue("@PrixMouvement", AchatDb.Pile.PrixMoyen);
                                        cmd.Parameters.AddWithValue("@PMP", AchatDb.Pile.PrixMoyen);
                                        cmd.Parameters.AddWithValue("@QteSortante", AchatDb.QteHuileAchetee);
                                        cmd.Parameters.AddWithValue("@pile_Id", AchatDb.Pile.Id);
                                        cmd.CommandType = CommandType.Text;
                                        cmd.ExecuteNonQuery();
                                    }
                                }


                                #endregion


                                #region update Pile

                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();

                                    using (SqlCommand cmd = new SqlCommand(SqlScript.UpdatePile, connection))
                                    {
                                        cmd.Parameters.AddWithValue("@Capacite", AchatDb.Pile.Capacite - AchatDb.QteHuileAchetee);
                                        cmd.Parameters.AddWithValue("@IdPile", AchatDb.Pile.Id);
                                        cmd.CommandType = CommandType.Text;
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                                #endregion

                                Pile PileUpdated = SqlJob.GetPile(AchatDb.Pile_Id); ;

                                // Update Prix Moyen Pile After Update Capacité
                                if (PileUpdated.Capacite == 0)
                                {
                                    SqlJob.UpdatePMPPile(PileUpdated.Id);

                                }

                                SqlJob.DeleteAchat(IDAchat);

                                Console.WriteLine("Traitement terminé avec succès");

                            }

                            else if (AchatDb.TypeAchat == TypeAchat.Huile && AchatDb.EtatAchat== EtatAchat.Reglee && totalAchatAgr != totalAvanceAgr)
                            {
                                Console.WriteLine("Traitement non effectué");
                            }


                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Achat introuvable");
                       
                       
                    }


                }
                else
                {
                    // Invalid input, ask the user to re-enter
                    Console.WriteLine("Code Achat Huile est invalide. Réessayer.");
                   

                }
            }

            // Add a method to define your validation logic
            bool IsValidCodeAchat(string code)
            {
                return !string.IsNullOrEmpty(code) && code.Length == 11 && code.StartsWith("HLE");
            }


           

        }
    }
}
