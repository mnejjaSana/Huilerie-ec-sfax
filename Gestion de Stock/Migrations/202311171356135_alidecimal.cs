namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alidecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Achats", "Poids", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Achats", "PrixLitre", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Achats", "QteLitre", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Achats", "QteRestStockhuile", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Achats", "MontantRegle", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Achats", "QteHuile", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Achats", "AvanceAvecAchat", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Achats", "Rendement", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Achats", "PUOlive", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Achats", "PUOliveFinal", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Achats", "MontantOpPrev", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Achats", "MontantReglement", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Achats", "MtAdeduire", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Achats", "MtAPayeAvecImpo", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Emplacements", "RENDEMENMOY", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Emplacements", "PrixMoyen", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Emplacements", "ValeurMasraf", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Emplacements", "LastPrixMoyen", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Agriculteurs", "Solde", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Agriculteurs", "SoldeAgriculteur", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Agriculteurs", "TotalAvances", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Agriculteurs", "TotalAchats", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Piles", "PrixMoyen", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Alimentations", "Montant", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Caisses", "MontantTotal", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Coffrecheques", "Montant", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Depenses", "Montant", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Salariers", "TotalNombreHeure", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Salariers", "TotalDeponse", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.HistoriquePaiementAchats", "MontantReglement", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.HistoriquePaiementAchats", "MontantRegle", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.HistoriquePaiementAchats", "ResteApayer", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.HistoriquePaiementSalaries", "MontantReglement", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.HistoriquePaiementSalaries", "MontantRegle", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.HistoriquePaiementSalaries", "ResteApayer", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.HistoriquePaiementVentes", "MontantReglement", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.HistoriquePaiementVentes", "MontantRegle", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.HistoriquePaiementVentes", "ResteApayer", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.LigneProductions", "QuantiteHuileProduite", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.LigneProductions", "RendementLignePTotal", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Productions", "QuantiteHuile", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Productions", "RendementReel", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Productions", "RendementMoyenPrevu", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Productions", "PUTotal", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.LigneVentes", "Remise", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.LigneVentes", "PrixHT", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.LigneVentes", "PrixMoyenPile", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Ventes", "TotalHT", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Ventes", "TotalTTC", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Ventes", "QteVendue", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Ventes", "MontantReglement", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Ventes", "MontantRegle", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Mouvements", "Montant", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.MouvementCaisses", "MontantSens", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.MouvementCaisses", "Montant", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.MouvementStocks", "PrixMouvement", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.MouvementStocks", "PMP", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.MouvementStockOlives", "PrixMouvement", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.MouvementStockOlives", "RENDEMENTMVT", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.MouvementStockOlives", "RENDEMENMOY", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.Prelevements", "Montant", c => c.Decimal(nullable: false, precision: 18, scale: 6));
            AlterColumn("dbo.VenteOlives", "Prix", c => c.Decimal(nullable: false, precision: 18, scale: 6));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VenteOlives", "Prix", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Prelevements", "Montant", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.MouvementStockOlives", "RENDEMENMOY", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.MouvementStockOlives", "RENDEMENTMVT", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.MouvementStockOlives", "PrixMouvement", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.MouvementStocks", "PMP", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.MouvementStocks", "PrixMouvement", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.MouvementCaisses", "Montant", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.MouvementCaisses", "MontantSens", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Mouvements", "Montant", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Ventes", "MontantRegle", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Ventes", "MontantReglement", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Ventes", "QteVendue", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Ventes", "TotalTTC", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Ventes", "TotalHT", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.LigneVentes", "PrixMoyenPile", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.LigneVentes", "PrixHT", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.LigneVentes", "Remise", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Productions", "PUTotal", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Productions", "RendementMoyenPrevu", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Productions", "RendementReel", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Productions", "QuantiteHuile", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.LigneProductions", "RendementLignePTotal", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.LigneProductions", "QuantiteHuileProduite", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.HistoriquePaiementVentes", "ResteApayer", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.HistoriquePaiementVentes", "MontantRegle", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.HistoriquePaiementVentes", "MontantReglement", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.HistoriquePaiementSalaries", "ResteApayer", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.HistoriquePaiementSalaries", "MontantRegle", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.HistoriquePaiementSalaries", "MontantReglement", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.HistoriquePaiementAchats", "ResteApayer", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.HistoriquePaiementAchats", "MontantRegle", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.HistoriquePaiementAchats", "MontantReglement", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Salariers", "TotalDeponse", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Salariers", "TotalNombreHeure", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Depenses", "Montant", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Coffrecheques", "Montant", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Caisses", "MontantTotal", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Alimentations", "Montant", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Piles", "PrixMoyen", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Agriculteurs", "TotalAchats", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Agriculteurs", "TotalAvances", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Agriculteurs", "SoldeAgriculteur", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Agriculteurs", "Solde", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Emplacements", "LastPrixMoyen", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Emplacements", "ValeurMasraf", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Emplacements", "PrixMoyen", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Emplacements", "RENDEMENMOY", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Achats", "MtAPayeAvecImpo", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Achats", "MtAdeduire", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Achats", "MontantReglement", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Achats", "MontantOpPrev", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Achats", "PUOliveFinal", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Achats", "PUOlive", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Achats", "Rendement", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Achats", "AvanceAvecAchat", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Achats", "QteHuile", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Achats", "MontantRegle", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Achats", "QteRestStockhuile", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Achats", "QteLitre", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Achats", "PrixLitre", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.Achats", "Poids", c => c.Decimal(nullable: false, precision: 18, scale: 3));
        }
    }
}
