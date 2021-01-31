/*
Created: 1/27/2021
Modified: 1/31/2021
Model: Balcony_Microsoft SQL Server 2008
Database: MS SQL Server 2008
*/


-- Create tables section -------------------------------------------------

-- Table user

CREATE TABLE [user]
(
 [user_id] Varchar(36) NOT NULL,
 [user_name] Varchar(500) NOT NULL,
 [user_identification] Char(10) NOT NULL,
 [user_status] Char(1) DEFAULT 'A' NOT NULL,
 [user_created] Datetime DEFAULT CURRENT_TIMESTAMP NOT NULL,
 [user_updated] Datetime NULL
)
ON [PRIMARY]
go

-- Add keys for table user

ALTER TABLE [user] ADD CONSTRAINT [PK_user] PRIMARY KEY ([user_id])
go

ALTER TABLE [user] ADD CONSTRAINT [user_identification] UNIQUE ([user_identification])
go

-- Table balcony

CREATE TABLE [balcony]
(
 [balcony_id] Varchar(36) NOT NULL,
 [balcony_name] Varchar(255) NOT NULL,
 [balcony_average] Int DEFAULT 0 NOT NULL,
 [balcony_status] Char(1) DEFAULT 'A' NOT NULL,
 [balcony_created] Datetime DEFAULT CURRENT_TIMESTAMP NOT NULL,
 [balcony_updated] Datetime NULL
)
ON [PRIMARY]
go

-- Add keys for table balcony

ALTER TABLE [balcony] ADD CONSTRAINT [PK_balcony] PRIMARY KEY ([balcony_id])
go

ALTER TABLE [balcony] ADD CONSTRAINT [balcony_name] UNIQUE ([balcony_name])
go

-- Table queue

CREATE TABLE [queue]
(
 [queue_id] Varchar(36) NOT NULL,
 [balcony_id] Varchar(36) NOT NULL,
 [user_id] Varchar(36) NOT NULL,
 [queue_status] Char(1) DEFAULT 'A' NOT NULL,
 [queue_created] Datetime DEFAULT CURRENT_TIMESTAMP NOT NULL,
 [queue_released] Datetime NULL,
 [queue_average] Int DEFAULT 0 NOT NULL
)
ON [PRIMARY]
go

-- Create indexes for table queue

CREATE INDEX [IX_FK_user__queue] ON [queue] ([user_id])
go

CREATE INDEX [IX_FK_balcony__queue] ON [queue] ([balcony_id])
go

-- Add keys for table queue

ALTER TABLE [queue] ADD CONSTRAINT [PK_queue] PRIMARY KEY ([queue_id])
go

-- Create foreign keys (relationships) section ------------------------------------------------- 


ALTER TABLE [queue] ADD CONSTRAINT [FK_balcony__queue] FOREIGN KEY ([balcony_id]) REFERENCES [balcony] ([balcony_id]) ON UPDATE NO ACTION ON DELETE NO ACTION
go



ALTER TABLE [queue] ADD CONSTRAINT [FK_user__queue] FOREIGN KEY ([user_id]) REFERENCES [user] ([user_id]) ON UPDATE CASCADE ON DELETE NO ACTION
go




