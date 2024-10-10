USE BD_FAZENDA;

-- Verifica se a procedure 'InserirCliente' existe e a exclui se existir
IF OBJECT_ID('InserirCliente', 'P') IS NOT NULL
    DROP PROCEDURE InserirCliente;
GO

-- Cria a procedure 'InserirCliente'
CREATE PROCEDURE InserirCliente
    @NomeCliente VARCHAR(100),    
    @Cpf VARCHAR(15),
    @Email VARCHAR(50),   
    @Senha VARCHAR(4)
AS
BEGIN
    INSERT INTO Cliente (NomeCliente, CPF, Email, Senha)
    VALUES (@NomeCliente, @Cpf, @Email, @Senha);
END;