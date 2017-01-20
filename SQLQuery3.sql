INSERT INTO 
	CalculoPrecoVendaDb.dbo.Ufs 
	(NomeUf, SiglaUf, AliquotaInterna, AliquotaFcp, ItensFcp, AliquotaInterestadual, AliquotaEmbarcacoes)
SELECT 
	NomeUf, SiglaUf, AliquotaInterna, AliquotaFcp, ItensFcp, AliquotaInterestadual, AliquotaEmbarcacoes
FROM
	[C:\USERS\RENATO.ALEGRANAUTICA\DOCUMENTS\VISUAL STUDIO 2015\PROJECTS\CALCULOPRECOVENDA\CALCULOPRECOVENDA\DATA\OLD.MDF].dbo.Ufs