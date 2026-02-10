SELECT TOP (1000) [Id]
      ,[Ativo]
      ,[DataCriacao]
      ,[Email]
      ,[Nome]
      ,[SenhaHash]
      ,[Username]
  FROM [VESTIGIA_DEV].[dbo].[Usuarios]


  SELECT * FROM SYS.foreign_key_columns
  WHERE referenced_column_id = OBJECT_ID('Usuarios')