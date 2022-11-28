-- Active: 1669607510115@@bobocat.mysql.database.azure.com@3306@mollysdatabase
CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL PRIMARY KEY COMMENT 'Primary Key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name VARCHAR(255) COMMENT 'User Name',
        email VARCHAR(255) COMMENT 'User Email',
        picture VARCHAR(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS recipes(
        id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        creatorId VARCHAR(255) NOT NULL COMMENT 'Creator Id', 
        title VARCHAR(255) NOT NULL COMMENT  'Title',
        instructions LONGTEXT NOT NULL COMMENT  'Instructions',
        category VARCHAR(255) NOT NULL,
        archived TINYINT DEFAULT 0,
        img VARCHAR(255) NOT NULL COMMENT  'Recipe Img',
        Foreign Key (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

    CREATE TABLE
    IF NOT EXISTS ingredients(
        id INT NOT NULL PRIMARY KEY AUTO_INCREMENT COMMENT  'Primary Key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        creatorId VARCHAR(255) NOT NULL COMMENT  'Creator Id',
        name VARCHAR(255) NOT NULL COMMENT  'Name',
        quantity VARCHAR(255) NOT NULL,
        recipeId INT NOT NULL,
        Foreign Key (recipeId) REFERENCES recipes(id) ON DELETE CASCADE,
        Foreign Key (creatorId) REFERENCES accounts(id) ON DELETE CASCADE 
    ) default charset utf8 COMMENT '';

    CREATE TABLE
    IF NOT EXISTS favorites(
        id INT NOT NULL PRIMARY KEY AUTO_INCREMENT COMMENT 'Primary Key', 
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        accountId VARCHAR(255) NOT NULL,
        recipeId INT NOT NULL,
        Foreign Key (accountId) REFERENCES accounts(id) ON DELETE CASCADE,
        Foreign Key (recipeId) REFERENCES recipes(id) ON DELETE CASCADE 
    ) default charset utf8 COMMENT '';