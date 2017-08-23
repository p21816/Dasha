
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/23/2017 11:20:30
-- Generated from EDMX file: D:\Max\BT\BankTransfersModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BankTransfers];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'MessageSet'
CREATE TABLE [dbo].[MessageSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SenderBankId] int  NOT NULL,
    [RecieverBankId] int  NOT NULL
);
GO

-- Creating table 'MessageSet_ResultMessage'
CREATE TABLE [dbo].[MessageSet_ResultMessage] (
    [ResultCode] int  NOT NULL,
    [Id] int  NOT NULL,
    [Related_Id] int  NOT NULL
);
GO

-- Creating table 'MessageSet_PaymentMessage'
CREATE TABLE [dbo].[MessageSet_PaymentMessage] (
    [SenderAccountId] int  NOT NULL,
    [RecieverAccountId] int  NOT NULL,
    [Amount] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'MessageSet'
ALTER TABLE [dbo].[MessageSet]
ADD CONSTRAINT [PK_MessageSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MessageSet_ResultMessage'
ALTER TABLE [dbo].[MessageSet_ResultMessage]
ADD CONSTRAINT [PK_MessageSet_ResultMessage]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MessageSet_PaymentMessage'
ALTER TABLE [dbo].[MessageSet_PaymentMessage]
ADD CONSTRAINT [PK_MessageSet_PaymentMessage]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Related_Id] in table 'MessageSet_ResultMessage'
ALTER TABLE [dbo].[MessageSet_ResultMessage]
ADD CONSTRAINT [FK_MessageResultMessage]
    FOREIGN KEY ([Related_Id])
    REFERENCES [dbo].[MessageSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MessageResultMessage'
CREATE INDEX [IX_FK_MessageResultMessage]
ON [dbo].[MessageSet_ResultMessage]
    ([Related_Id]);
GO

-- Creating foreign key on [Id] in table 'MessageSet_ResultMessage'
ALTER TABLE [dbo].[MessageSet_ResultMessage]
ADD CONSTRAINT [FK_ResultMessage_inherits_Message]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[MessageSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'MessageSet_PaymentMessage'
ALTER TABLE [dbo].[MessageSet_PaymentMessage]
ADD CONSTRAINT [FK_PaymentMessage_inherits_Message]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[MessageSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------