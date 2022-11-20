USE [test]

GO
/****** Object:  Table [test].[testUsersXml]    Script Date: 29.1.2018 9:29:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [test].[dbo].[testUsersXml](
                [id] [int] NOT NULL,
                [dataXml] [xml] NOT NULL,
CONSTRAINT [PK_testUsersXml] PRIMARY KEY CLUSTERED
(
                [id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [test].[dbo].[testUsersXml] ([id], [dataXml]) VALUES (1, N'<data><row name="Ðorðe" surname="Jankoviæ" email="georg.jankovic@bs.com" /><row name="Miško" surname="Žaliè" email="misko.zalic@something.org" /><row name="Šime" surname="Èargaž" email="sime.cargazg@steza.com" /><row name="Ðuro" surname="Ðakoviè" email="duro.dakovic@bs.si" /><row name="Funny Chars" surname="õÕù??ð?" email="funny.chars@steza.com" /><row name="Trevor" surname="Chapman" email="trevor.chapman@test.net" /><row name="Boris" surname="Paige" email="boris.paige@steza.net" /><row name="Boris" surname="Davidson" email="boris.davidson@test.org" /><row name="Jack" surname="Metcalfe" email="jack.metcalfe@test.com" /><row name="Evan" surname="James" email="evan.james@steza.org" /><row name="Trevor" surname="Martin" email="trevor.martin@steza.org" /><row name="Jonathan" surname="Robertson" email="jonathan.robertson@steza.org" /><row name="Julian" surname="Hudson" email="julian.hudson@test.org" /><row name="Leonard" surname="Vaughan" email="leonard.vaughan@test.com" /><row name="Dan" surname="Slater" email="dan.slater@steza.org" /><row name="Richard" surname="Peters" email="richard.peters@test.net" /><row name="Piers" surname="Scott" email="piers.scott@steza.org" /><row name="Christian" surname="Bailey" email="christian.bailey@steza.org" /><row name="Cameron" surname="Piper" email="cameron.piper@test.com" /><row name="Harry" surname="Abraham" email="harry.abraham@test.com" /><row name="Joshua" surname="Forsyth" email="joshua.forsyth@steza.com" /><row name="Justin" surname="Burgess" email="justin.burgess@steza.org" /><row name="Isaac" surname="Hughes" email="isaac.hughes@test.org" /><row name="Richard" surname="Wilkins" email="richard.wilkins@test.org" /><row name="Warren" surname="Langdon" email="warren.langdon@test.org" /><row name="Joshua" surname="Arnold" email="joshua.arnold@steza.org" /><row name="Richard" surname="Rees" email="richard.rees@steza.net" /><row name="Gavin" surname="Peake" email="gavin.peake@test.net" /><row name="Michael" surname="Brown" email="michael.brown@steza.com" /><row name="Victor" surname="Parr" email="victor.parr@test.net" /></data>')
GO