DROP TABLE "member";
DROP TABLE "task";
DROP TABLE "project";
DROP TABLE "comment";
DROP TABLE "status_change";
DROP TABLE "status";
DROP TABLE "user";

CREATE TABLE "user"
(
	id 			SERIAL,
	add_date	TIMESTAMP,
	add_login	VARCHAR(32),
	modif_date	TIMESTAMP,
	modif_login	VARCHAR(32),
	active		BOOLEAN NOT NULL DEFAULT TRUE,
	login 		VARCHAR(32),
	password 	VARCHAR(1024)
);

CREATE TABLE "status"
(
	id 			SERIAL,
	add_date	TIMESTAMP,
	add_login	VARCHAR(32),
	modif_date	TIMESTAMP,
	modif_login	VARCHAR(32),
	active		BOOLEAN NOT NULL DEFAULT TRUE,
	
);

CREATE TABLE "status_change"
(
	id 				SERIAL,
	add_date		TIMESTAMP,
	add_login		VARCHAR(32),
	modif_date		TIMESTAMP,
	modif_login		VARCHAR(32),
	active			BOOLEAN NOT NULL DEFAULT TRUE,
	from_status_id	INTEGER NOT NULL,
	to_status_id	INTEGER NOT NULL,
	CONSTRAINT UNQ_status_change UNIQUE (from_status_id, to_status_id)
)

CREATE TABLE "comment"
(
	id 			SERIAL,
	add_date	TIMESTAMP,
	add_login	VARCHAR(32),
	modif_date	TIMESTAMP,
	modif_login	VARCHAR(32),
	active		BOOLEAN NOT NULL DEFAULT TRUE,
	text 		VARCHAR2(4000)
);

CREATE TABLE "project"
(
	id 			SERIAL,
	add_date	TIMESTAMP,
	add_login	VARCHAR(32),
	modif_date	TIMESTAMP,
	modif_login	VARCHAR(32),
	active		BOOLEAN NOT NULL DEFAULT TRUE,
	name 		VARCAHR2(128),
		
);

CREATE TABLE "task"
(
	id 			SERIAL,
	add_date	TIMESTAMP,
	add_login	VARCHAR(32),
	modif_date	TIMESTAMP,
	modif_login	VARCHAR(32),
	active		BOOLEAN NOT NULL DEFAULT TRUE,
	name 		VARCHAR2(128),
	
);

CREATE TABLE "member"
(
	id 			SERIAL,
	add_date	TIMESTAMP,
	add_login	VARCHAR(32),
	modif_date	TIMESTAMP,
	modif_login	VARCHAR(32),
	active		BOOLEAN NOT NULL DEFAULT TRUE,
	user_id 	INTEGER NOT NULL,
	project_id 	INTEGER NOT NULL,
	permission 	INTEGER,
	CONSTRAINT UNQ_member UNIQUE (user_id, project_id)
);

