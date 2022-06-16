CREATE FUNCTION user_Insert_NewUser(first_n text, last_n text, gender_in text, email_in text, date_of_birth_in text)
    RETURNS void
AS
$BODY$
BEGIN
    insert into person (first_name, last_name, email, gender, date_of_birth)
    values(
            cast(first_n AS varchar),
            cast(last_n AS varchar),
            cast(email_in AS varchar),
            gender_in = 'male',
            cast(date_of_birth_in AS date)
        );
END
$BODY$
LANGUAGE plpgsql