CREATE SCHEMA cardsgame;

DROP SEQUENCE IF EXISTS cardsgame.players_id_seq;

DROP SEQUENCE IF EXISTS cardsgame.scores_id_seq;

DROP SEQUENCE IF EXISTS cardsgame.games_id_seq;

DROP SEQUENCE IF EXISTS cardsgame.gamesteps_id_seq;

CREATE SEQUENCE cardsgame.players_id_seq INCREMENT 1 START 1;

CREATE SEQUENCE cardsgame.scores_id_seq INCREMENT 1 START 1;

CREATE SEQUENCE cardsgame.games_id_seq INCREMENT 1 START 1;

CREATE SEQUENCE cardsgame.gamesteps_id_seq INCREMENT 1 START 1;

DROP TABLE IF EXISTS cardsgame.players CASCADE;

CREATE TABLE cardsgame.players
(
	Id integer NOT NULL   DEFAULT NEXTVAL(('cardsgame."players_id_seq"'::text)::regclass),
	Name varchar(500) UNIQUE NOT NULL,
	NumberOfWins integer NOT NULL
	
);
ALTER TABLE cardsgame.players ADD CONSTRAINT PK_Players
	PRIMARY KEY (Id);
	
DROP TABLE IF EXISTS cardsgame.scores CASCADE;

CREATE TABLE cardsgame.scores
(
	Id integer NOT NULL   DEFAULT NEXTVAL(('cardsgame."scores_id_seq"'::text)::regclass),
	PlayerId integer NOT NULL,
	NumberOfWins integer NOT NULL
	
);
ALTER TABLE cardsgame.scores ADD CONSTRAINT PK_Scores
	PRIMARY KEY (Id);
ALTER TABLE cardsgame.scores ADD CONSTRAINT FK_Scores_Players
	FOREIGN KEY (PlayerId) REFERENCES cardsgame.players (Id) ON DELETE No Action ON UPDATE No Action;

DROP TABLE IF EXISTS cardsgame.games CASCADE;

CREATE TABLE cardsgame.games
(
	Id integer NOT NULL   DEFAULT NEXTVAL(('cardsgame."games_id_seq"'::text)::regclass),
	Name varchar(500) UNIQUE NOT NULL,
	PlayerId integer UNIQUE NOT NULL,
	NumberOfSteps integer NOT NULL,
	IsWinner boolean NULL
	
);
ALTER TABLE cardsgame.games ADD CONSTRAINT PK_Games
	PRIMARY KEY (Id);
ALTER TABLE cardsgame.games ADD CONSTRAINT FK_Games_Players
	FOREIGN KEY (PlayerId) REFERENCES cardsgame.players (Id) ON DELETE No Action ON UPDATE No Action;

DROP TABLE IF EXISTS cardsgame.gamesteps CASCADE;

CREATE TABLE cardsgame.gamesteps
(
	Id integer NOT NULL   DEFAULT NEXTVAL(('cardsgame."players_id_seq"'::text)::regclass),
	PlayerId integer UNIQUE NOT NULL,
	CardValue integer NOT NULL,
	IsStepWinner boolean NULL,
	CardsLeft integer NOT NULL
	
);
ALTER TABLE cardsgame.gamesteps ADD CONSTRAINT PK_Gamesteps
	PRIMARY KEY (Id);
ALTER TABLE cardsgame.gamesteps ADD CONSTRAINT FK_Gamesteps_Players
	FOREIGN KEY (PlayerId) REFERENCES cardsgame.players (Id) ON DELETE No Action ON UPDATE No Action;
	
DROP TABLE IF EXISTS cardsgame.gamesnumberofplayers CASCADE;
	
CREATE TABLE cardsgame.gamesnumberofplayers
(
	Id integer NOT NULL   DEFAULT NEXTVAL(('cardsgame."gamesnumberofplayers_id_seq"'::text)::regclass),
	GameId integer NOT NULL,
	NumberOfPlayers integer NOT NULL
);

ALTER TABLE cardsgame.gamesnumberofplayers ADD CONSTRAINT PK_GamesNumberOfPlayers
	PRIMARY KEY (Id);
ALTER TABLE cardsgame.gamesnumberofplayers ADD CONSTRAINT FK_GamesNumberOfPlayers_Games
	FOREIGN KEY (GameId) REFERENCES cardsgame.games (Id) ON DELETE No Action ON UPDATE No Action;


-- create table connection BEGIN
DROP TABLE IF EXISTS cardsgame.gamesgamesteps CASCADE;

CREATE TABLE cardsgame.gamesgamesteps
(
	GameId integer NOT NULL,
	GameStepId integer NOT NULL
);


CREATE INDEX IXFK_GamesGameSteps_Games ON cardsgame.gamesgamesteps (GameId ASC);

CREATE INDEX IXFK_GamesGameSteps_GameSteps ON cardsgame.gamesgamesteps (GameStepId ASC);

ALTER TABLE cardsgame.gamesgamesteps ADD CONSTRAINT FK_GamesGameSteps_Games
	FOREIGN KEY (GameId) REFERENCES cardsgame.games (Id) ON DELETE No Action ON UPDATE No Action;
ALTER TABLE cardsgame.gamesgamesteps ADD CONSTRAINT FK_GamesGameSteps_Gamesteps
	FOREIGN KEY (GameStepId) REFERENCES cardsgame.gamesteps (Id) ON DELETE No Action ON UPDATE No Action;
-- create table connection END



	