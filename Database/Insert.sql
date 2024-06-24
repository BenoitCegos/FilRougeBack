
INSERT INTO User (nom) VALUES ('User 1');
INSERT INTO User (nom) VALUES ('User 2');
INSERT INTO User (nom) VALUES ('User 3');

INSERT INTO Projet (nom) VALUES ('Projet 1');
INSERT INTO Projet (nom) VALUES ('Projet 2');
INSERT INTO Projet (nom) VALUES ('Projet 3');

INSERT INTO Liste (nom, projet_id) VALUES ('Liste 1', 1);
INSERT INTO Liste (nom, projet_id) VALUES ('Liste 2', 1);
INSERT INTO Liste (nom, projet_id) VALUES ('Liste 3', 2);
INSERT INTO Liste (nom, projet_id) VALUES ('Liste 4', 2);
INSERT INTO Liste (nom, projet_id) VALUES ('Liste 5', 3);
INSERT INTO Liste (nom, projet_id) VALUES ('Liste 6', 3);


INSERT INTO Tache (nom, liste_id,endDate) VALUES ('Tache 1', 1, '2021-12-31');
INSERT INTO Tache (nom, liste_id,endDate) VALUES ('Tache 2', 1, '2021-12-31');
INSERT INTO Tache (nom, liste_id,endDate) VALUES ('Tache 3', 2, '2021-12-31');
INSERT INTO Tache (nom, liste_id,endDate) VALUES ('Tache 4', 2, '2021-12-31');
INSERT INTO Tache (nom, liste_id,endDate) VALUES ('Tache 5', 3, '2021-12-31');
INSERT INTO Tache (nom, liste_id,endDate) VALUES ('Tache 6', 3, '2021-12-31');
INSERT INTO Tache (nom, liste_id,endDate) VALUES ('Tache 7', 4, '2021-12-31');
INSERT INTO Tache (nom, liste_id,endDate) VALUES ('Tache 8', 4, '2021-12-31');
INSERT INTO Tache (nom, liste_id,endDate) VALUES ('Tache 9', 5, '2021-12-31');
INSERT INTO Tache (nom, liste_id,endDate) VALUES ('Tache 10', 5, '2021-12-31');
INSERT INTO Tache (nom, liste_id,endDate) VALUES ('Tache 11', 6, '2021-12-31');
INSERT INTO Tache (nom, liste_id,endDate) VALUES ('Tache 12', 6, '2021-12-31');




INSERT INTO Commentaire (contenu, tache_id) VALUES ('Commentaire 1', 1);
INSERT INTO Commentaire (contenu, tache_id) VALUES ('Commentaire 2', 1);
INSERT INTO Commentaire (contenu, tache_id) VALUES ('Commentaire 3', 2);
INSERT INTO Commentaire (contenu, tache_id) VALUES ('Commentaire 4', 2);
INSERT INTO Commentaire (contenu, tache_id) VALUES ('Commentaire 5', 3);
INSERT INTO Commentaire (contenu, tache_id) VALUES ('Commentaire 6', 3);
INSERT INTO Commentaire (contenu, tache_id) VALUES ('Commentaire 7', 4);
INSERT INTO Commentaire (contenu, tache_id) VALUES ('Commentaire 8', 4);
INSERT INTO Commentaire (contenu, tache_id) VALUES ('Commentaire 9', 5);
INSERT INTO Commentaire (contenu, tache_id) VALUES ('Commentaire 10', 5);
INSERT INTO Commentaire (contenu, tache_id) VALUES ('Commentaire 11', 6);
INSERT INTO Commentaire (contenu, tache_id) VALUES ('Commentaire 12', 6);
