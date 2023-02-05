CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture',
        savePage varchar(255) COMMENT 'Save Page',
        savePageTitle varchar(255) COMMENT 'Save Page Title',
        gold int DEFAULT 0 COMMENT 'Gold',
        health int DEFAULT 100 COMMENT 'Health',
        attack int DEFAULT 1 COMMENT 'Attack',
        lives int DEFAULT 3 COMMENT 'Lives',
        characterModel INT NOT NULL DEFAULT 1 COMMENT 'Character Model',
        FOREIGN KEY (characterModel) REFERENCES playerModel(id)
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS monsters(
        id INT NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'Monster Name',
        health int DEFAULT 0 COMMENT 'Health',
        attack int DEFAULT 0 COMMENT 'Attack',
        gold int DEFAULT 0 COMMENT 'Gold',
        picture varchar(255) COMMENT 'Monster Picture',
        description varchar(255) COMMENT 'Monster Description',
        monsterModel INT NOT NULL DEFAULT 1 COMMENT 'Monster Model',
        FOREIGN KEY (monsterModel) REFERENCES monsterModels(id)
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS items(
        id INT NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        name varchar(255) COMMENT 'Item Name',
        attack int DEFAULT 0 COMMENT 'Attack',
        gold int DEFAULT 0 COMMENT 'Gold',
        picture varchar(255) COMMENT 'Item Picture',
        description varchar(255) COMMENT 'Item Description',
        itemModel INT NOT NULL DEFAULT 1 COMMENT 'Item Model',
        FOREIGN KEY (itemModel) REFERENCES itemsModels(id)
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS accountItems(
        id INT NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        accountId varchar(255) COMMENT 'Account Id',
        itemId INT COMMENT 'Item Id',
        FOREIGN KEY (accountId) REFERENCES accounts(id),
        FOREIGN KEY (itemId) REFERENCES items(id)
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS accountMonsters(
        id INT NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        accountId varchar(255) COMMENT 'Account Id',
        monsterId INT COMMENT 'Monster Id',
        FOREIGN KEY (accountId) REFERENCES accounts(id),
        FOREIGN KEY (monsterId) REFERENCES monsters(id)
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS accountMonstersItems(
        id INT NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        accountMonsterId INT NOT NULL COMMENT 'Account Monster Id',
        itemId INT NOT NULL COMMENT 'Item Id',
        FOREIGN KEY (accountMonsterId) REFERENCES accountMonsters(id),
        FOREIGN KEY (itemId) REFERENCES items(id)
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS playerModel(
        id INT NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'Player Model Name',
        description varchar(255) COMMENT 'Player Model Description',
        frontPicture varchar(255) COMMENT 'Player Model Front Picture',
        backPicture varchar(255) COMMENT 'Player Model Back Picture',
        leftPicture varchar(255) COMMENT 'Player Model Left Picture',
        rightPicture varchar(255) COMMENT 'Player Model Right Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS monsterModels(
        id INT NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'Monster Model Name',
        description varchar(255) COMMENT 'Monster Model Description',
        frontPicture varchar(255) COMMENT 'Monster Model Front Picture',
        backPicture varchar(255) COMMENT 'Monster Model Back Picture',
        leftPicture varchar(255) COMMENT 'Monster Model Left Picture',
        rightPicture varchar(255) COMMENT 'Monster Model Right Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS itemsModels(
        id INT NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'Item Model Name',
        description varchar(255) COMMENT 'Item Model Description',
        frontPicture varchar(255) COMMENT 'Item Model Front Picture',
        backPicture varchar(255) COMMENT 'Item Model Back Picture',
        leftPicture varchar(255) COMMENT 'Item Model Left Picture',
        rightPicture varchar(255) COMMENT 'Item Model Right Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS project(
        id INT NOT NULL primary key COMMENT 'primary key',
        url varchar(255) COMMENT 'Project Url',
        name varchar(255) COMMENT 'Project Name',
        description varchar(255) COMMENT 'Project Description',
        picture varchar(255) COMMENT 'Project Picture'
    ) DEFAULT CHARSET utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS itemShop(
        id INT NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'Item Shop Name',
        description varchar(255) COMMENT 'Item Shop Description',
        itemId INT NOT NULL COMMENT 'Item Id',
        price INT NOT NULL COMMENT 'Item Price',
        playerModel INT NOT NULL COMMENT 'Player Model',
        FOREIGN KEY (itemId) REFERENCES items(id),
        FOREIGN KEY (playerModel) REFERENCES playerModel(id)
    ) DEFAULT CHARSET utf8 COMMENT '';