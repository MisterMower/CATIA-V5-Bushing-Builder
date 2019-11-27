Module CATIAOperations
    Public Inch As Double = 25.4
    Public Function GetCATIA() As INFITF.Application
        Try
            Dim CATIA As INFITF.Application = GetObject(vbNullString, "CATIA.Application")
            Return CATIA
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function GetRootDocument(CATIA As INFITF.Application) As ProductStructureTypeLib.ProductDocument
        Try
            Dim RootDocument As ProductStructureTypeLib.ProductDocument = CATIA.ActiveDocument
            Return RootDocument
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Module
