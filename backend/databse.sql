-- DROP SCHEMA IF EXISTS postgres CASCADE;
CREATE SCHEMA postgres;

-- PROFILE table
CREATE TABLE postgres.PROFILE (
    profile_id SERIAL PRIMARY KEY,
    profile_name VARCHAR(100),
    profile_status BOOLEAN
);

-- TRANSACTION table
CREATE TABLE postgres.TRANSACTION (
    transaction_id SERIAL PRIMARY KEY,
    transaction_name VARCHAR(100),
    transaction_number INT,
    transaction_status BOOLEAN
);

-- USER table
CREATE TABLE postgres.USER (
    user_id SERIAL PRIMARY KEY,
    user_name VARCHAR(100),
    user_surname VARCHAR(100),
    user_email VARCHAR(100),
    user_password VARCHAR(255),
    user_refresh_token VARCHAR(150),
    profile_id INT,
    CONSTRAINT fk_USER_PROFILE FOREIGN KEY (profile_id) REFERENCES postgres.PROFILE(profile_id)
);

-- PROFILE_TRANSACTION table
CREATE TABLE postgres.PROFILE_TRANSACTION (
    profile_transaction_id SERIAL PRIMARY KEY,
    profile_id INT,
    transaction_id INT,
    CONSTRAINT fk_PROFILE_TRANSACTION_PROFILE FOREIGN KEY (profile_id) REFERENCES postgres.PROFILE(profile_id),
    CONSTRAINT fk_PROFILE_TRANSACTION_TRANSACTION FOREIGN KEY (transaction_id) REFERENCES postgres.TRANSACTION(transaction_id)
);