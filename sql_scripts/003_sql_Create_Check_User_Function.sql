-- FUNCTION: public."Check_User"(character varying, character varying)

-- DROP FUNCTION public."Check_User"(character varying, character varying);

CREATE OR REPLACE FUNCTION public."Check_User"(
	uname character varying,
	pword character varying)
    RETURNS SETOF "User" 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
AS $BODY$
BEGIN

	RETURN QUERY 
	SELECT "Id", "DisplayName"
	FROM public."Users" 
	WHERE "Username" = uname AND "Password" = pword;

END;
$BODY$;

ALTER FUNCTION public."Check_User"(character varying, character varying)
    OWNER TO postgres;
