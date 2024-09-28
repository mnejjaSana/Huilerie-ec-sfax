namespace AnnulationAchatHuile.Sql
{
    public class SqlScript
    {

        public static string GetAchat = @"select * FROM [dbo].[Achats] where Numero=@NumAchat";

        public static string GetFounisseur = @"select * FROM [dbo].[Agriculteurs] where Id=@IdFournisseur";

        public static string GetPile = @"select * FROM [dbo].[Piles] where Id=@IdPile";

        public static string GetCoffreCheque = @"select * FROM [dbo].[Coffrecheques] where Montant=@Montant and NumCheque = @NumCheque and Bank=@Bank and DateEcheance= @DateEcheance";

        public static string UpdateMouvementStock = @"UPDATE [dbo].[MouvementStocks] SET[Achat_Id] =Null WHERE Achat_Id=@IDAchat and Commentaire like 'Achat Huile%'";

        public static string UpdateMouvementCaisse = @"UPDATE [dbo].[MouvementCaisses] SET[Achat_Id] =Null WHERE Achat_Id=@IDAchat and Commentaire like 'Avance Agriculteur_%'";

        public static string DeleteAchat = @"DELETE FROM[dbo].[Achats] WHERE Id =@IdAchat";

        public static string DeleteAvance = @"DELETE FROM[dbo].[Achats] WHERE Numero =@NumAvance";

        public static string DeleteDepense = @"DELETE FROM[dbo].[Depenses] WHERE Commentaire =@commantaire";
      
        public static string DeleteHistoriqueAchat = @"DELETE FROM[dbo].[HistoriquePaiementAchats] WHERE [NumAchat] =@NumAchat and [Commentaire]='Règlement Automatique Par Avance '";


        public static string DeleteDepenseById = @"DELETE FROM[dbo].[Depenses] WHERE Id =@IdDep";

        public static string DeleteCoffreCheque = @"DELETE FROM[dbo].[Coffrecheques] WHERE Id =@IdCoffre";

        public static string GetMaxIdDepense = @"select MAX(Id) from [dbo].[Depenses]";

        public static string GetMaxIdAlimentation = @"select MAX(Id) from [dbo].[Alimentations]";

        public static string GetMaxIdMouvementStock = @"select MAX(Id) from [dbo].[MouvementStocks]";

        public static string AddAlimentation = @"INSERT INTO[dbo].[Alimentations]
        ([Numero]
          ,[DateCreation]
          ,[Source]
          ,[Montant]
          ,[Commentaire]
          ,[Tiers]
          ,[Agriculteur_Id]
          ,[Client_Id])
          VALUES
          (@Numero
           ,@DateCreation
           ,9
           ,@Montant 
           ,@Commentaire
           ,NULL
           ,NULL
           ,NULL)";

        // alimentation
        public static string AddMvtCaisse = @"INSERT INTO[dbo].[MouvementCaisses]
        ([Numero]
          ,[Date]
          ,[Sens]
          ,[Source]
          ,[Commentaire]
          ,[MontantSens]
          ,[Montant]
          ,[CodeTiers]
          ,[Achat_Id]
          ,[Agriculteur_Id]
          ,[Client_Id]
          ,[NatureDepense_Id]
          ,[Salarie_Id]
          ,[Vente_Id])
    VALUES
          (@Numero
           ,@DateCreation
           ,0
           ,@Source
           ,@Commentaire
           ,@MontantSens
           ,@Montant
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL
           ,NULL)";

        public static string AddMvtStockSortieDivers = @"INSERT INTO[dbo].[MouvementStocks]
        ([Numero]                       
           ,[QuantiteProduite]         
           ,[QuantiteAchetee]
           ,[QuantiteVendue]
           ,[QuantiteSOD]
           ,[Sens]
           ,[Commentaire]
           ,[Date]
           ,[Qualite]
           ,[QuantitePileInitial]
           ,[QuantitePileFinal]
           ,[PrixMouvement]
           ,[PMP]
           ,[QteEntrante]
           ,[QteSortante]
           ,[Code]
           ,[Intitulé]
           ,[Achat_Id]
           ,[pile_Id]
           ,[Prod_Id]
           ,[Vente_Id])
     VALUES
           (@Numero                        
           ,0
           ,0
           ,0
           ,@QuantiteSOD
           ,0
           ,@Commentaire
           ,@Date
           ,@Qualite
           ,@QuantitePileInitial
           ,@QuantitePileFinal
           ,@PrixMouvement
           ,@PMP
           ,0
           ,@QteSortante
           ,NULL
           ,NULL
           ,NULL
           ,@pile_Id
           ,NULL
           ,NULL)";

        public static string UpdatePile = @"UPDATE[dbo].[Piles] SET [Capacite] = @Capacite WHERE Id=@IdPile";

        public static string UpdatePMPPile = @"UPDATE[dbo].[Piles] SET  [PrixMoyen] =0 WHERE Id=@IdPile";
       
        public static string GetSoldeCaisse = @"select [MontantTotal] FROM [dbo].[Caisses] where Id=1";

        public static string UpdateSoldeCaisse = @"UPDATE[dbo].[Caisses] SET[MontantTotal] = @MontantTotal where Id=1";
        public static string GetListHistoriqueAchat = @"select * from [dbo].[HistoriquePaiementAchats] where Founisseur_Id=@IdAgr and NumAchat=@NumAchat";
        public static string DeleteDepenseAvance = @"DELETE FROM[dbo].[Depenses] WHERE Commentaire like @commantaire and Agriculteur_Id=@agrId and Montant=@Montant";
        public static string GetAvance = @"select * FROM[dbo].[Achats] WHERE Founisseur_Id=@IdFournisseur and Avance = 1 and MontantRegle=@MontantRegle";

    }
}
