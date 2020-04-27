# X12Parser

This is an open source .NET C# implementation of an X12 Parser.

The parser allows for a specification of any X12 transaction set to create a generic X12 xml representation of the hierarchical data contained within the X12 document.

No database integration is required by design, though  you can use the ImportX12 app to parse into a SQL Server database and skip the XML.

8/27/2019: Added some error checking.
4/25/2020: Created new branch to merge changes to the master branch of Intelligenz/X12Parser by bvanfleet.
