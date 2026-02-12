SELECT TOP (1000) [Id]
      ,[Ativo]
      ,[DataCriacao]
      ,[Email]
      ,[Nome]
      ,[SenhaHash]
      ,[Username]
  FROM [VESTIGIA_DEV].[dbo].[Usuarios]

  SELECT TOP (1000) [Id]
      ,[NomeConta]
      ,[Saldo]
      ,[SaldoInicial]
      ,[Tipo]
      ,[IdUsuario]
      ,[DataCriacao]
      ,[NumeroConta]
  FROM [VESTIGIA_DEV].[dbo].[Contas]

  SELECT * FROM SYS.foreign_key_columns
  WHERE referenced_column_id = OBJECT_ID('Usuarios')