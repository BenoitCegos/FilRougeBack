
CREATE TABLE IF NOT EXISTS User (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    nom VARCHAR(255) NOT NULL
);

-- Create if not exist Projet Tables
CREATE TABLE IF NOT EXISTS Projet (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    nom VARCHAR(255) NOT NULL,
    createdAt VARCHAR(20) NOT NULL
);

-- Create Liste tables
CREATE TABLE IF NOT EXISTS Liste (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    nom VARCHAR(255) NOT NULL,
    projet_id INT,
    FOREIGN KEY (projet_id) REFERENCES Projet(id) ON DELETE CASCADE
);

-- Create Tache tables
CREATE TABLE IF NOT EXISTS Tache (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    nom VARCHAR(255) NOT NULL,
    description TEXT,
    createdAt VARCHAR(20) NOT NULL,
    endDate VARCHAR(20),
    liste_id INT,
    FOREIGN KEY (liste_id) REFERENCES Liste(id) ON DELETE CASCADE
);

-- Create Commentaire tables
CREATE TABLE IF NOT EXISTS Commentaire (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    contenu TEXT NOT NULL,
    createdAt VARCHAR(20) NOT NULL,
    tache_id INT,
    FOREIGN KEY (tache_id) REFERENCES Tache(id) ON DELETE CASCADE
);




