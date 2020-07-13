-- FUNCTION: public."Insert_User"(character varying[], character varying[], character varying[])

-- DROP FUNCTION public."Insert_User"(character varying[], character varying[], character varying[]);

CREATE OR REPLACE FUNCTION public."Insert_User"(
	username character varying[],
	password character varying[],
	"displayName" character varying[])
    RETURNS void
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$
BEGIN

	INSERT INTO public."Users"("Username", "Password", "DisplayName")
	VALUES (username, upassword, displayName);
	
END;
	$BODY$;

ALTER FUNCTION public."Insert_User"(character varying[], character varying[], character varying[])
    OWNER TO postgres;
