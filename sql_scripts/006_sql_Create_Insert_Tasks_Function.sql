-- FUNCTION: public."Insert_Tasks"(date, date, text, taskstatus, tasktype)

-- DROP FUNCTION public."Insert_Tasks"(date, date, text, taskstatus, tasktype);

CREATE OR REPLACE FUNCTION public."Insert_Tasks"(
	"createdDate" date,
	"requiredByDate" date,
	description text,
	status taskstatus,
	"taskType" tasktype)
    RETURNS void
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
AS $BODY$
BEGIN

INSERT INTO public."Tasks"("CreatedDate", "RequiredByDate", "Description", "Status", "Type")
	VALUES (createdDate, requiredByDate, description, status, taskType);

END;
$BODY$;

ALTER FUNCTION public."Insert_Tasks"(date, date, text, taskstatus, tasktype)
    OWNER TO postgres;
