namespace AnnulationAchatOlive.Sql
{
    public class SqlScript
    {

        public static string GetAchat = @"select * FROM [dbo].[Achats] where Numero=@NumAchat";

        public static string GetFounisseur = @"select * FROM [dbo].[Agriculteurs] where Id=@IdFournisseur";

        public static string GetMasraf = @"select * FROM [dbo].[Emplacements] where Id=@IdEmplacement";

        public static string GetCoffreCheque = @"select * FROM [dbo].[Coffrecheques] where Montant=@Montant and NumCheque = @NumCheque and Bank=@Bank and DateEcheance= @DateEcheance";
        
        public static string UpdateMouvementCaisse = @"UPDATE [dbo].[MouvementCaisses] SET[Achat_Id] =Null WHERE Achat_Id=@IDAchat";

        public static string DeleteAchat = @"DELETE FROM[dbo].[Achats] WHERE Id =@IdAchat";

        public static string DeleteAvance = @"DELETE FROM[dbo].[Achats] WHERE Numero =@NumAvance";
        
        public static string GetAvance = @"select * FROM[dbo].[Achats] WHERE Founisseur_Id=@IdFournisseur and Avance = 1 and MontantRegle=@MontantRegle";
        
        public static string DeleteDepenseAvance = @"DELETE FROM[dbo].[Depenses] WHERE Commentaire like @commantaire and Agriculteur_Id=@agrId and Montant=@Montant";

        public static string DeleteDepense = @"DELETE FROM[dbo].[Depenses] WHERE Commentaire like @commantaire";

        public static string DeleteHistoriqueAchat = @"DELETE FROM[dbo].[HistoriquePaiementAchats] WHERE [NumAchat] =@NumAchat";

        public static string DeleteDepenseById = @"DELETE FROM[dbo].[Depenses] WHERE Id =@IdDep";

        public static string DeleteCoffreCheque = @"DELETE FROM[dbo].[Coffrecheques] WHERE Id =@IdCoffre";

        public static string GetMaxIdDepense = @"select MAX(Id) from [dbo].[Depenses]";

        public static string GetMaxIdAlimentation = @"select MAX(Id) from [dbo].[Alimentations]";

        public static string GetMaxIdMouvementStock = @"select MAX(Id) from [dbo].[MouvementStockOlives]";

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

        public static string AddMvtStockOlive = @"INSERT INTO [dbo].[MouvementStockOlives]
           ([Numero]
           ,[Sens]
           ,[Commentaire]
           ,[Date]
           ,[QuantiteMasrafInitial]
           ,[QuantiteMasrafFinal]
           ,[PrixMouvement]
           ,[QteEntrante]
           ,[QteSortante]
           ,[RENDEMENTMVT]
           ,[RENDEMENMOY]
           ,[Code]
           ,[Intitulé]
           ,[Achat_Id]
           ,[Emplacement_Id])
     VALUES
           (
            @Numero
           ,0
           ,@Commentaire
           ,@Date
           ,@QuantiteMasrafInitial
           ,@QuantiteMasrafFinal
           ,@PrixMouvement
           ,0
           ,@QteSortante
           ,@RENDEMENTMVT
           ,@RENDEMENMOY
           ,@Code
           ,@Intitulé
           ,NULL
           ,@Emplacement_Id
)";


        
        public static string UpdateMasraf = @"UPDATE[dbo].[Emplacements] SET [Quantite] = @Qte WHERE Id=@IdMasraf";

        public static string UpdateValuesMasraf = @"UPDATE[dbo].[Emplacements] SET
       [RENDEMENMOY] =0
      ,[PrixMoyen]=0
      ,[ValeurMasraf]=0
      ,[LastPrixMoyen]=@PrixMoyen WHERE Id=@IdMasraf";
       
        public static string GetSoldeCaisse = @"select [MontantTotal] FROM [dbo].[Caisses] where Id=1";

        public static string UpdateSoldeCaisse = @"UPDATE[dbo].[Caisses] SET[MontantTotal] = @MontantTotal where Id=1";

        public static string UpdateAvance = @"UPDATE[dbo].[Achats] SET [MontantRegle] = @Montant where Numero=@NumAchat";

        public static string GetListHistoriqueAchat = @"select * from [dbo].[HistoriquePaiementAchats] where Founisseur_Id=@IdAgr and NumAchat=@NumAchat";

        public static string GetListDepenseHistAchat = @" select *  FROM [dbo].[Depenses] where Commentaire like @com";


    }
}
