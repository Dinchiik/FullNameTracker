FullNameTracker — это консольное приложение для хранения, поиска и управления ФИО в базе данных PostgreSQL.  
Данные загружаются из текстового файла `txt.txt`, хранятся в базе данных и могут быть найдены, добавлены или удалены через консольные команды.
Для запуска проекта необходимо создать базу данных.

Откройте pgAdmin или DBeaver и выполните следующий SQL-код:

CREATE DATABASE NameRepository;
\c NameRepository;

CREATE TABLE fio_list (
    id SERIAL PRIMARY KEY,
    surname VARCHAR(50) NOT NULL,
    name VARCHAR(50) NOT NULL,
    patronymic VARCHAR(50) NOT NULL,
    UNIQUE(surname, name, patronymic)
);
