CREATE PROCEDURE user_Insert_NewUser(first_n varchar, last_n varchar, gender_in varchar, email_in varchar, date_of_birth_in date)

AS
$BODY$
BEGIN
    insert into person (first_name, last_name, email, gender, date_of_birth)
    values(
            first_n,
            last_n,
            email_in,
            gender_in = 'male',
            date_of_birth_in
    );
END
$BODY$
LANGUAGE plpgsql