DECLARE @vrstica int, @XMLDokument nvarchar(max), @xmlRAW XML

SELECT @xmlRAW=dataXml FROM [test].[dbo].[testUsersXml]

SET @XMLDokument = '<data>
 <row name="Boris" surname="Paige" email="boris.paige@steza.net" />
  <row name="Boris" surname="Davidson" email="boris.davidson@test.org" />
  <row name="Jack" surname="Metcalfe" email="jack.metcalfe@test.com" />
  <row name="Evan" surname="Jameš" email="evan.james@steza.org" />
</data>'

--EXEC sp_xml_preparedocument @vrstica output, @XMLDokument
EXEC sp_xml_preparedocument @vrstica output, @xmlRAW

INSERT INTO [test].[dbo].[SeznamUporabnikov]

SELECT NEWID(), s.[name] AS Ime, s.surname AS Priimek, s.email AS Email, 0

FROM

openxml(@vrstica, 'data/row',1)

with ([name] varchar(20), surname varchar(30), email varchar(30)) as s

