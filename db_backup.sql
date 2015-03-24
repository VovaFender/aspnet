use aspnet;

CREATE TABLE User(
	id INT NOT NULL AUTO_INCREMENT,
    name varchar(10),
    user_role INT NOT NULL,
    PRIMARY KEY ( id )
);

CREATE TABLE UserRole(
	id INT NOT NULL AUTO_INCREMENT,
    name varchar(10),
	PRIMARY KEY ( id )
);

ALTER TABLE user
ADD FOREIGN KEY (user_role) REFERENCES userrole(id)

INSERT INTO userrole(name)
VALUES('admin')

INSERT INTO userrole(name)
VALUES('user')

INSERT INTO userrole(name)
VALUES('moderator')

INSERT INTO user(name, user_role)
VALUES('Patrick', 1)

INSERT INTO user(name, user_role)
VALUES('Bob', 2)

INSERT INTO user(name, user_role)
VALUES('Charlie', 2)