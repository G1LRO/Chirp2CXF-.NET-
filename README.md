# Chirp2CXF-.NET-
A .NET utility to convert from CHIRP CSV export files to the CXF file format used by the Quansheng UV-K5 radio CPS

With this utility will create a new backup file for the Quansheng "Portable Radio CPS" program. Load this into the Quansheng CPS and write to the radio.

The input files will be a generic 'donor' save file from the Quansheng CPS, and a CSV export from CHIRP. Backup your Quansheng radio to the CPS to create the .cxf file. Note the donor .cxf file needs to have at least one memory defined so the correct tags exist for the program to replace with the CHIRP data.

Note the donor .cxf file needs to have at least one memory defined so the correct tags exist for the program to replace with the CHIRP data.

Be careful to use the "File->Export as CSV" option in Chirp and not the entire Chirp save file for your radio.The Chirp export CSV only contains the channel information.

The input CXF file will contain everything else you need to configure your Quansheng UV-K5 such as radio settings, scan lists, dtmf things etc.

This utility inserts the CHIRP CSV information into your donor CXF file and provides a result file with the CHIRP channels included. Take this file and load into the Quansheng CPS to program your radio.
