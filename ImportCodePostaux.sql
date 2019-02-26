 declare @sCheminFichierCsv varchar(250)='D:\Banard\Mes Proj C#\Projet de Synthese\Web.ITroc\Patch_POP_1_2_725\Sql\201412_CodesPostaux_MAJ.csv';
 

 IF OBJECT_ID('tempdb..#NCP') IS NOT NULL
		DROP TABLE #NCP
create table #NCP
	(	NCP_ID varchar(6) COLLATE SQL_Latin1_General_CP1_CI_AS ,	
		NCP_CP varchar(5) COLLATE SQL_Latin1_General_CP1_CI_AS ,
		NCP_VILLE varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	 )
	
		
	declare @sSql as varchar(250);
	set @sSql = 'BULK INSERT #NCP FROM ''' + @sCheminFichierCsv + ''' WITH (FIRSTROW = 2,FIELDTERMINATOR ='';'',ROWTERMINATOR =''\n'')';
	exec(@sSql);

	select NCP_CP,NCP_VILLE from #NCP

	DELETE FROM CODEPOSTAL
	INSERT INTO CODEPOSTAL select NCP_CP,NCP_VILLE from #NCP
	
	DROP TABLE #NCP