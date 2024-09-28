namespace Gestion_de_Stock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Achats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.String(),
                        Date = c.DateTime(nullable: false),
                        TypeOlive = c.Int(),
                        TypeAchat = c.Int(nullable: false),
                        NbSacs = c.Int(nullable: false),
                        Poids = c.Decimal(nullable: false, precision: 18, scale: 3),
                        PrixLitre = c.Decimal(nullable: false, precision: 18, scale: 3),
                        QteLitre = c.Decimal(nullable: false, precision: 18, scale: 3),
                        QteRestStockhuile = c.Decimal(nullable: false, precision: 18, scale: 3),
                        EtatAchat = c.Int(nullable: false),
                        MontantReglement = c.Decimal(nullable: false, precision: 18, scale: 3),
                        MontantRegle = c.Decimal(nullable: false, precision: 18, scale: 3),
                        StatutProd = c.Int(nullable: false),
                        NuméroBon = c.String(),
                        EtatAvance = c.Int(nullable: false),
                        Qualite = c.Int(nullable: false),
                        QteHuileAchetee = c.Int(nullable: false),
                        QteHuile = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Annulle = c.String(),
                        AvanceAvecAchat = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Avance = c.Boolean(nullable: false),
                        QteOliveAchetee = c.Int(nullable: false),
                        Rendement = c.Decimal(nullable: false, precision: 18, scale: 3),
                        PUOlive = c.Decimal(nullable: false, precision: 18, scale: 3),
                        PUOliveFinal = c.Decimal(nullable: false, precision: 18, scale: 3),
                        MontantOpPrev = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Emplacement_Id = c.Int(),
                        Founisseur_Id = c.Int(),
                        Pile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Emplacements", t => t.Emplacement_Id)
                .ForeignKey("dbo.Agriculteurs", t => t.Founisseur_Id)
                .ForeignKey("dbo.Piles", t => t.Pile_Id)
                .Index(t => t.Emplacement_Id)
                .Index(t => t.Founisseur_Id)
                .Index(t => t.Pile_Id);
            
            CreateTable(
                "dbo.Emplacements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.String(),
                        Intitule = c.String(),
                        Quantite = c.Int(nullable: false),
                        Article = c.Int(nullable: false),
                        RENDEMENMOY = c.Decimal(nullable: false, precision: 18, scale: 3),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Agriculteurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        cin = c.String(),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Numero = c.String(),
                        Tel = c.String(),
                        Vehicule = c.String(),
                        Solde = c.Decimal(nullable: false, precision: 18, scale: 3),
                        SoldeAgriculteur = c.Decimal(nullable: false, precision: 18, scale: 3),
                        TotalAvances = c.Decimal(nullable: false, precision: 18, scale: 3),
                        TotalAchats = c.Decimal(nullable: false, precision: 18, scale: 3),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Piles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Intitule = c.String(),
                        Numero = c.String(),
                        article = c.Int(nullable: false),
                        CapaciteMax = c.Int(nullable: false),
                        Capacite = c.Int(nullable: false),
                        PrixMoyen = c.Decimal(nullable: false, precision: 18, scale: 3),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Affaires",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Intitule = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Alimentations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        Source = c.Int(nullable: false),
                        Montant = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Commentaire = c.String(),
                        Tiers = c.String(),
                        Agriculteur_Id = c.Int(),
                        Client_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agriculteurs", t => t.Agriculteur_Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .Index(t => t.Agriculteur_Id)
                .Index(t => t.Client_Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.String(),
                        Intitule = c.String(),
                        Adresse = c.String(),
                        Tel = c.String(),
                        MatriculeFiscale = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Banques",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.String(),
                        Intitule = c.String(),
                        NumRIB = c.String(),
                        Adresse = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Caisses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MontantTotal = c.Decimal(nullable: false, precision: 18, scale: 3),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Coffrecheques",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreation = c.DateTime(nullable: false),
                        NumVente = c.String(),
                        NomSalarier = c.String(),
                        Montant = c.Decimal(nullable: false, precision: 18, scale: 3),
                        NumCheque = c.String(),
                        Bank = c.String(),
                        DateEcheance = c.DateTime(),
                        Commentaire = c.String(),
                        Client_Id = c.Int(),
                        Depense_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .ForeignKey("dbo.Depenses", t => t.Depense_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.Depense_Id);
            
            CreateTable(
                "dbo.Depenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreation = c.DateTime(nullable: false),
                        Numero = c.String(),
                        Nature = c.Int(nullable: false),
                        Montant = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Commentaire = c.String(),
                        ModePaiement = c.String(),
                        Tiers = c.String(),
                        Bank = c.String(),
                        DateEcheance = c.DateTime(),
                        NumCheque = c.String(),
                        CodeTiers = c.String(),
                        Agriculteur_Id = c.Int(),
                        Salarie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agriculteurs", t => t.Agriculteur_Id)
                .ForeignKey("dbo.Salariers", t => t.Salarie_Id)
                .Index(t => t.Agriculteur_Id)
                .Index(t => t.Salarie_Id);
            
            CreateTable(
                "dbo.Salariers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Intitule = c.String(),
                        numero = c.String(),
                        Tel = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HistoriquePaiementAchats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreation = c.DateTime(nullable: false),
                        NumAchat = c.String(),
                        TypeAchat = c.Int(nullable: false),
                        MontantReglement = c.Decimal(nullable: false, precision: 18, scale: 3),
                        MontantRegle = c.Decimal(nullable: false, precision: 18, scale: 3),
                        ResteApayer = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Commentaire = c.String(),
                        Founisseur_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agriculteurs", t => t.Founisseur_Id)
                .Index(t => t.Founisseur_Id);
            
            CreateTable(
                "dbo.HistoriquePaiementSalaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreation = c.DateTime(nullable: false),
                        ModeReglement = c.Int(nullable: false),
                        MontantReglement = c.Decimal(nullable: false, precision: 18, scale: 3),
                        MontantRegle = c.Decimal(nullable: false, precision: 18, scale: 3),
                        ResteApayer = c.Decimal(nullable: false, precision: 18, scale: 3),
                        NumCheque = c.Int(nullable: false),
                        DateEcheance = c.DateTime(),
                        Bank = c.String(),
                        Coffre = c.Boolean(nullable: false),
                        Salarie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Salariers", t => t.Salarie_Id)
                .Index(t => t.Salarie_Id);
            
            CreateTable(
                "dbo.HistoriquePaiementVentes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreation = c.DateTime(nullable: false),
                        NumVente = c.String(),
                        IdVente = c.Int(nullable: false),
                        IdClient = c.Int(nullable: false),
                        IntituleClient = c.String(),
                        NumClient = c.String(),
                        ModeReglement = c.Int(nullable: false),
                        MontantReglement = c.Decimal(nullable: false, precision: 18, scale: 3),
                        MontantRegle = c.Decimal(nullable: false, precision: 18, scale: 3),
                        ResteApayer = c.Decimal(nullable: false, precision: 18, scale: 3),
                        NumCheque = c.String(),
                        DateEcheance = c.DateTime(),
                        Bank = c.String(),
                        Coffre = c.Boolean(nullable: false),
                        Commentaire = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LigneProductions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuantiteHuileProduite = c.Decimal(nullable: false, precision: 18, scale: 3),
                        NombreSacs = c.Int(nullable: false),
                        DateFinProd = c.DateTime(nullable: false),
                        AchatId = c.String(),
                        NuméroBon = c.Int(nullable: false),
                        prod_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Productions", t => t.prod_Id)
                .Index(t => t.prod_Id);
            
            CreateTable(
                "dbo.Productions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumeroProduction = c.String(),
                        NuméroBon = c.String(),
                        DateProd = c.DateTime(nullable: false),
                        DateFinProd = c.DateTime(nullable: false),
                        dureeProduction = c.String(),
                        Machine = c.Int(nullable: false),
                        StatutProd = c.Int(nullable: false),
                        QuantiteHuile = c.Decimal(nullable: false, precision: 18, scale: 3),
                        TypeAchat = c.Int(nullable: false),
                        RendementReel = c.Decimal(nullable: false, precision: 18, scale: 3),
                        QuantiteOlive = c.String(),
                        Achat_Id = c.Int(),
                        Emplacement_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Achats", t => t.Achat_Id)
                .ForeignKey("dbo.Emplacements", t => t.Emplacement_Id)
                .Index(t => t.Achat_Id)
                .Index(t => t.Emplacement_Id);
            
            CreateTable(
                "dbo.LigneStocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Quantite = c.Int(nullable: false),
                        article = c.Int(nullable: false),
                        QuantitePileInitial = c.Int(nullable: false),
                        QuantitePileFinal = c.Int(nullable: false),
                        pile_Id = c.Int(),
                        production_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Piles", t => t.pile_Id)
                .ForeignKey("dbo.Productions", t => t.production_Id)
                .Index(t => t.pile_Id)
                .Index(t => t.production_Id);
            
            CreateTable(
                "dbo.LigneSalariers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SalarierId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        NombreHeure = c.Int(nullable: false),
                        SocieteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LigneVentes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        ArticleVente = c.Int(nullable: false),
                        Remise = c.Decimal(nullable: false, precision: 18, scale: 3),
                        TVA = c.Int(nullable: false),
                        PrixHT = c.Decimal(nullable: false, precision: 18, scale: 3),
                        IdPile = c.Int(nullable: false),
                        NomPile = c.String(),
                        QuantitePileInitial = c.Int(nullable: false),
                        QuantitePileFinal = c.Int(nullable: false),
                        PrixMoyenPile = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Vente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ventes", t => t.Vente_Id)
                .Index(t => t.Vente_Id);
            
            CreateTable(
                "dbo.Ventes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.String(),
                        IdClient = c.Int(nullable: false),
                        IntituleClient = c.String(),
                        NumClient = c.String(),
                        Date = c.DateTime(nullable: false),
                        Commentaire = c.String(),
                        Camion = c.String(),
                        Adresse = c.String(),
                        NomChauffeur = c.String(),
                        EtatVente = c.Int(nullable: false),
                        TotalHT = c.Decimal(nullable: false, precision: 18, scale: 3),
                        TotalTTC = c.Decimal(nullable: false, precision: 18, scale: 3),
                        QteVendue = c.Decimal(nullable: false, precision: 18, scale: 3),
                        MontantReglement = c.Decimal(nullable: false, precision: 18, scale: 3),
                        MontantRegle = c.Decimal(nullable: false, precision: 18, scale: 3),
                        ModeReglement = c.Int(nullable: false),
                        NumeroCheque = c.String(),
                        DateEcheance = c.DateTime(),
                        Bank = c.String(),
                        Coffre = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Mouvements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.String(),
                        Libelle = c.String(),
                        Sens = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Montant = c.Decimal(nullable: false, precision: 18, scale: 3),
                        UserNo = c.Int(nullable: false),
                        Tiers = c.String(),
                        TiersId = c.Int(nullable: false),
                        Nature = c.Int(nullable: false),
                        SocieteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MouvementCaisses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.String(),
                        Date = c.DateTime(nullable: false),
                        Sens = c.Int(nullable: false),
                        Source = c.String(),
                        Commentaire = c.String(),
                        MontantSens = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Montant = c.Decimal(nullable: false, precision: 18, scale: 3),
                        CodeTiers = c.String(),
                        Achat_Id = c.Int(),
                        Agriculteur_Id = c.Int(),
                        Client_Id = c.Int(),
                        NatureDepense_Id = c.Int(),
                        Salarie_Id = c.Int(),
                        Vente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Achats", t => t.Achat_Id)
                .ForeignKey("dbo.Agriculteurs", t => t.Agriculteur_Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .ForeignKey("dbo.Depenses", t => t.NatureDepense_Id)
                .ForeignKey("dbo.Salariers", t => t.Salarie_Id)
                .ForeignKey("dbo.Ventes", t => t.Vente_Id)
                .Index(t => t.Achat_Id)
                .Index(t => t.Agriculteur_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.NatureDepense_Id)
                .Index(t => t.Salarie_Id)
                .Index(t => t.Vente_Id);
            
            CreateTable(
                "dbo.MouvementStocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.String(),
                        QuantiteProduite = c.Int(nullable: false),
                        QuantiteAchetee = c.Int(nullable: false),
                        QuantiteVendue = c.Int(nullable: false),
                        QuantiteSOD = c.Int(nullable: false),
                        Sens = c.Int(nullable: false),
                        Commentaire = c.String(),
                        Date = c.DateTime(nullable: false),
                        Qualite = c.Int(nullable: false),
                        QuantitePileInitial = c.Int(nullable: false),
                        QuantitePileFinal = c.Int(nullable: false),
                        PrixMouvement = c.Decimal(nullable: false, precision: 18, scale: 3),
                        PMP = c.Decimal(nullable: false, precision: 18, scale: 3),
                        QteEntrante = c.Int(nullable: false),
                        QteSortante = c.Int(nullable: false),
                        Code = c.String(),
                        Intitulé = c.String(),
                        Achat_Id = c.Int(),
                        pile_Id = c.Int(),
                        Prod_Id = c.Int(),
                        Vente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Achats", t => t.Achat_Id)
                .ForeignKey("dbo.Piles", t => t.pile_Id)
                .ForeignKey("dbo.Productions", t => t.Prod_Id)
                .ForeignKey("dbo.Ventes", t => t.Vente_Id)
                .Index(t => t.Achat_Id)
                .Index(t => t.pile_Id)
                .Index(t => t.Prod_Id)
                .Index(t => t.Vente_Id);
            
            CreateTable(
                "dbo.MouvementStockOlives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.String(),
                        Sens = c.Int(nullable: false),
                        Commentaire = c.String(),
                        Date = c.DateTime(nullable: false),
                        QuantiteMasrafInitial = c.Int(nullable: false),
                        QuantiteMasrafFinal = c.Int(nullable: false),
                        PrixMouvement = c.Decimal(nullable: false, precision: 18, scale: 3),
                        QteEntrante = c.Int(nullable: false),
                        QteSortante = c.Int(nullable: false),
                        RENDEMENTMVT = c.Decimal(nullable: false, precision: 18, scale: 3),
                        RENDEMENMOY = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Code = c.String(),
                        Intitulé = c.String(),
                        Achat_Id = c.Int(),
                        Emplacement_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Achats", t => t.Achat_Id)
                .ForeignKey("dbo.Emplacements", t => t.Emplacement_Id)
                .Index(t => t.Achat_Id)
                .Index(t => t.Emplacement_Id);
            
            CreateTable(
                "dbo.PointageJournaliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Salarier_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Salariers", t => t.Salarier_Id)
                .Index(t => t.Salarier_Id);
            
            CreateTable(
                "dbo.Prelevements",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Num = c.String(),
                        Date = c.DateTime(nullable: false),
                        Banque = c.String(),
                        Commentaire = c.String(),
                        Montant = c.Decimal(nullable: false, precision: 18, scale: 3),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Societes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RaisonSocial = c.String(),
                        Capitale = c.String(),
                        CodePostale = c.String(),
                        Ville = c.String(),
                        Adresse = c.String(),
                        MatriculFiscal = c.String(),
                        Telephone = c.String(),
                        Enregister = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Utilisateurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Mail = c.String(),
                        SocieteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VenteOlives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.String(),
                        ClientId = c.Int(nullable: false),
                        ClientNumero = c.String(),
                        Date = c.DateTime(nullable: false),
                        Commentaire = c.String(),
                        Prix = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Quantite = c.Int(nullable: false),
                        ArticleId = c.Int(nullable: false),
                        EmplacementId = c.Int(nullable: false),
                        ReferenceId = c.Int(nullable: false),
                        Camion = c.String(),
                        Adresse = c.String(),
                        NomChauffeur = c.String(),
                        SocieteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PointageJournaliers", "Salarier_Id", "dbo.Salariers");
            DropForeignKey("dbo.MouvementStockOlives", "Emplacement_Id", "dbo.Emplacements");
            DropForeignKey("dbo.MouvementStockOlives", "Achat_Id", "dbo.Achats");
            DropForeignKey("dbo.MouvementStocks", "Vente_Id", "dbo.Ventes");
            DropForeignKey("dbo.MouvementStocks", "Prod_Id", "dbo.Productions");
            DropForeignKey("dbo.MouvementStocks", "pile_Id", "dbo.Piles");
            DropForeignKey("dbo.MouvementStocks", "Achat_Id", "dbo.Achats");
            DropForeignKey("dbo.MouvementCaisses", "Vente_Id", "dbo.Ventes");
            DropForeignKey("dbo.MouvementCaisses", "Salarie_Id", "dbo.Salariers");
            DropForeignKey("dbo.MouvementCaisses", "NatureDepense_Id", "dbo.Depenses");
            DropForeignKey("dbo.MouvementCaisses", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.MouvementCaisses", "Agriculteur_Id", "dbo.Agriculteurs");
            DropForeignKey("dbo.MouvementCaisses", "Achat_Id", "dbo.Achats");
            DropForeignKey("dbo.LigneVentes", "Vente_Id", "dbo.Ventes");
            DropForeignKey("dbo.LigneStocks", "production_Id", "dbo.Productions");
            DropForeignKey("dbo.LigneStocks", "pile_Id", "dbo.Piles");
            DropForeignKey("dbo.LigneProductions", "prod_Id", "dbo.Productions");
            DropForeignKey("dbo.Productions", "Emplacement_Id", "dbo.Emplacements");
            DropForeignKey("dbo.Productions", "Achat_Id", "dbo.Achats");
            DropForeignKey("dbo.HistoriquePaiementSalaries", "Salarie_Id", "dbo.Salariers");
            DropForeignKey("dbo.HistoriquePaiementAchats", "Founisseur_Id", "dbo.Agriculteurs");
            DropForeignKey("dbo.Coffrecheques", "Depense_Id", "dbo.Depenses");
            DropForeignKey("dbo.Depenses", "Salarie_Id", "dbo.Salariers");
            DropForeignKey("dbo.Depenses", "Agriculteur_Id", "dbo.Agriculteurs");
            DropForeignKey("dbo.Coffrecheques", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Alimentations", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Alimentations", "Agriculteur_Id", "dbo.Agriculteurs");
            DropForeignKey("dbo.Achats", "Pile_Id", "dbo.Piles");
            DropForeignKey("dbo.Achats", "Founisseur_Id", "dbo.Agriculteurs");
            DropForeignKey("dbo.Achats", "Emplacement_Id", "dbo.Emplacements");
            DropIndex("dbo.PointageJournaliers", new[] { "Salarier_Id" });
            DropIndex("dbo.MouvementStockOlives", new[] { "Emplacement_Id" });
            DropIndex("dbo.MouvementStockOlives", new[] { "Achat_Id" });
            DropIndex("dbo.MouvementStocks", new[] { "Vente_Id" });
            DropIndex("dbo.MouvementStocks", new[] { "Prod_Id" });
            DropIndex("dbo.MouvementStocks", new[] { "pile_Id" });
            DropIndex("dbo.MouvementStocks", new[] { "Achat_Id" });
            DropIndex("dbo.MouvementCaisses", new[] { "Vente_Id" });
            DropIndex("dbo.MouvementCaisses", new[] { "Salarie_Id" });
            DropIndex("dbo.MouvementCaisses", new[] { "NatureDepense_Id" });
            DropIndex("dbo.MouvementCaisses", new[] { "Client_Id" });
            DropIndex("dbo.MouvementCaisses", new[] { "Agriculteur_Id" });
            DropIndex("dbo.MouvementCaisses", new[] { "Achat_Id" });
            DropIndex("dbo.LigneVentes", new[] { "Vente_Id" });
            DropIndex("dbo.LigneStocks", new[] { "production_Id" });
            DropIndex("dbo.LigneStocks", new[] { "pile_Id" });
            DropIndex("dbo.Productions", new[] { "Emplacement_Id" });
            DropIndex("dbo.Productions", new[] { "Achat_Id" });
            DropIndex("dbo.LigneProductions", new[] { "prod_Id" });
            DropIndex("dbo.HistoriquePaiementSalaries", new[] { "Salarie_Id" });
            DropIndex("dbo.HistoriquePaiementAchats", new[] { "Founisseur_Id" });
            DropIndex("dbo.Depenses", new[] { "Salarie_Id" });
            DropIndex("dbo.Depenses", new[] { "Agriculteur_Id" });
            DropIndex("dbo.Coffrecheques", new[] { "Depense_Id" });
            DropIndex("dbo.Coffrecheques", new[] { "Client_Id" });
            DropIndex("dbo.Alimentations", new[] { "Client_Id" });
            DropIndex("dbo.Alimentations", new[] { "Agriculteur_Id" });
            DropIndex("dbo.Achats", new[] { "Pile_Id" });
            DropIndex("dbo.Achats", new[] { "Founisseur_Id" });
            DropIndex("dbo.Achats", new[] { "Emplacement_Id" });
            DropTable("dbo.VenteOlives");
            DropTable("dbo.Utilisateurs");
            DropTable("dbo.Societes");
            DropTable("dbo.Prelevements");
            DropTable("dbo.PointageJournaliers");
            DropTable("dbo.MouvementStockOlives");
            DropTable("dbo.MouvementStocks");
            DropTable("dbo.MouvementCaisses");
            DropTable("dbo.Mouvements");
            DropTable("dbo.Ventes");
            DropTable("dbo.LigneVentes");
            DropTable("dbo.LigneSalariers");
            DropTable("dbo.LigneStocks");
            DropTable("dbo.Productions");
            DropTable("dbo.LigneProductions");
            DropTable("dbo.HistoriquePaiementVentes");
            DropTable("dbo.HistoriquePaiementSalaries");
            DropTable("dbo.HistoriquePaiementAchats");
            DropTable("dbo.Salariers");
            DropTable("dbo.Depenses");
            DropTable("dbo.Coffrecheques");
            DropTable("dbo.Caisses");
            DropTable("dbo.Banques");
            DropTable("dbo.Clients");
            DropTable("dbo.Alimentations");
            DropTable("dbo.Affaires");
            DropTable("dbo.Piles");
            DropTable("dbo.Agriculteurs");
            DropTable("dbo.Emplacements");
            DropTable("dbo.Achats");
        }
    }
}
