-- FUNCTION: public."Insert_AssignedTo"(integer, integer, date, date)

-- DROP FUNCTION public."Insert_AssignedTo"(integer, integer, date, date);

CREATE OR REPLACE FUNCTION public."Insert_AssignedTo"(
	"userId" integer,
	"taskId" integer,
	"startDate" date,
	"endDate" date)
    RETURNS void
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$BEGIN

	INSERT INTO public."AssignedTo "("UserId", "TaskId", "StartDate", "EndDate")
	VALUES (userId, taskId, startDate, endDate);

END;
$BODY$;

ALTER FUNCTION public."Insert_AssignedTo"(integer, integer, date, date)
    OWNER TO postgres;
