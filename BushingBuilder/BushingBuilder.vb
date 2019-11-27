Public Class FormBushingBuilder
    Public CATIAV5 As INFITF.Application
    Public BushingID As Double
    Public BushingOD As Double
    Public BushingLength As Double
    Private Sub FormBushingBuilder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CATIAV5 = GetCATIA()
        If CATIAV5 Is Nothing Then
            MsgBox("CATIA V5 is not running. Start CATIA V5 before running the bushing builder.", vbOKOnly + vbInformation, "CATIA V5 Not Running")
            Close()
            Exit Sub
        End If
    End Sub
    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        Close()
    End Sub
    Private Sub ButtonBuildBushing_Click(sender As Object, e As EventArgs) Handles ButtonBuildBushing.Click
        Try
            BushingOD = CDbl(ComboBoxBushingOD.Text)
        Catch ex As Exception
            MsgBox("The bushing OD value is invalid. Enter a positive decimal number.", vbOKOnly + vbInformation, "Invalid Bushing OD")
            Exit Sub
        End Try
        Try
            BushingID = CDbl(TextBoxBushingID.Text)
        Catch ex As Exception
            MsgBox("The bushing ID value is invalid. Enter a positive decimal number.", vbOKOnly + vbInformation, "Invalid Bushing ID")
            Exit Sub
        End Try
        Try
            BushingLength = CDbl(ComboBoxBushingLength.Text)
        Catch ex As Exception
            MsgBox("The bushing length value is invalid. Enter a positive decimal number.", vbOKOnly + vbInformation, "Invalid Bushing Length")
            Exit Sub
        End Try

        Dim Documents As INFITF.Documents = CATIAV5.Documents
        Dim Document As INFITF.Document = Documents.Add("Part")
        Dim Part As MECMOD.Part = Document.Part
        Dim Bodies As MECMOD.Bodies = Part.Bodies
        Dim Body As MECMOD.Body = Bodies.Item("PartBody")
        Dim Sketches As MECMOD.Sketches = Body.Sketches
        Dim OriginElements As MECMOD.OriginElements = Part.OriginElements
        Dim PlaneXY As INFITF.AnyObject = OriginElements.PlaneXY
        Dim Sketch As MECMOD.Sketch = Sketches.Add(PlaneXY)
        Dim SketchOrientation(8)
        SketchOrientation(0) = 0
        SketchOrientation(1) = 0
        SketchOrientation(2) = 0
        SketchOrientation(3) = 1
        SketchOrientation(4) = 0
        SketchOrientation(5) = 0
        SketchOrientation(6) = 0
        SketchOrientation(7) = 1
        SketchOrientation(8) = 0
        Sketch.SetAbsoluteAxisData(SketchOrientation)
        Part.InWorkObject = Sketch
        Dim Factory2D As MECMOD.Factory2D = Sketch.OpenEdition()
        Dim GeometricElements As MECMOD.GeometricElements = Sketch.GeometricElements
        Dim Axis2D As MECMOD.Axis2D = GeometricElements.Item("AbsoluteAxis")
        Dim HLine2D As MECMOD.Line2D = Axis2D.GetItem("HDirection")
        HLine2D.ReportName = 1
        Dim VLine2D As MECMOD.Line2D = Axis2D.GetItem("VDirection")
        VLine2D.ReportName = 2
        Dim ODCircle2D As MECMOD.Circle2D = Factory2D.CreateClosedCircle(0, 0, 25.4)
        Dim ODPoint2D As MECMOD.Point2D = Axis2D.GetItem("Origin")
        ODCircle2D.CenterPoint = ODPoint2D
        ODCircle2D.ReportName = 3
        Dim Constraints As MECMOD.Constraints = Sketch.Constraints
        Dim ODCircle2DReference As INFITF.Reference = Part.CreateReferenceFromObject(ODCircle2D)
        Dim ODConstraint = Constraints.AddMonoEltCst(MECMOD.CatConstraintType.catCstTypeRadius, ODCircle2DReference)
        ODConstraint.Mode = MECMOD.CatConstraintMode.catCstModeDrivingDimension
        Dim ODCircleDiameter As KnowledgewareTypeLib.Dimension = ODConstraint.Dimension
        ODCircleDiameter.Value = BushingOD * 25.4 / 2

        Dim IDCircle2D As MECMOD.Circle2D = Factory2D.CreateClosedCircle(0, 0, 25.4)
        Dim IDPoint2D As MECMOD.Point2D = Axis2D.GetItem("Origin")
        IDCircle2D.CenterPoint = IDPoint2D
        IDCircle2D.ReportName = 4
        Dim IDCircle2DReference As INFITF.Reference = Part.CreateReferenceFromObject(IDCircle2D)
        Dim IDConstraint = Constraints.AddMonoEltCst(MECMOD.CatConstraintType.catCstTypeRadius, IDCircle2DReference)
        IDConstraint.Mode = MECMOD.CatConstraintMode.catCstModeDrivingDimension
        Dim IDCircleDiameter As KnowledgewareTypeLib.Dimension = IDConstraint.Dimension
        IDCircleDiameter.Value = BushingID * 25.4 / 2
        Sketch.CloseEdition()

        Part.InWorkObject = Body
        Part.Update()
        Dim ShapeFactory As PARTITF.ShapeFactory = Part.ShapeFactory
        Dim Pad As PARTITF.Pad = ShapeFactory.AddNewPad(Sketch, 0)
        Dim FirstLimit As PARTITF.Limit = Pad.FirstLimit
        Dim PadHeight As KnowledgewareTypeLib.Dimension = FirstLimit.Dimension
        PadHeight.Value = BushingLength * 25.4

        Dim DummyReference As INFITF.Reference = Part.CreateReferenceFromName("")
        Dim Chamfer = ShapeFactory.AddNewChamfer(DummyReference, PARTITF.CatChamferPropagation.catTangencyChamfer, PARTITF.CatChamferMode.catLengthAngleChamfer, PARTITF.CatChamferOrientation.catNoReverseChamfer, 1, 45)
        Dim IDChamferReference As INFITF.Reference = Part.CreateReferenceFromBRepName("REdge:(Edge:(Face:(Brp:(Pad.1;2);None:();Cf11:());Face:(Brp:(Pad.1;0:(Brp:(Sketch.1;4)));None:();Cf11:());None:(Limits1:();Limits2:());Cf11:());WithTemporaryBody;WithoutBuildError;WithSelectingFeatureSupport;MFBRepVersion_CXR15)", Pad)
        Dim ODChamferReference As INFITF.Reference = Part.CreateReferenceFromBRepName("REdge:(Edge:(Face:(Brp:(Pad.1;1);None:();Cf11:());Face:(Brp:(Pad.1;0:(Brp:(Sketch.1;3)));None:();Cf11:());None:(Limits1:();Limits2:());Cf11:());WithTemporaryBody;WithoutBuildError;WithSelectingFeatureSupport;MFBRepVersion_CXR15)", Pad)
        Chamfer.AddElementToChamfer(ODChamferReference)
        Chamfer.AddElementToChamfer(IDChamferReference)
        Chamfer.Mode = PARTITF.CatChamferMode.catLengthAngleChamfer
        Chamfer.Propagation = PARTITF.CatChamferPropagation.catTangencyChamfer
        Chamfer.Orientation = PARTITF.CatChamferOrientation.catNoReverseChamfer
        Chamfer.Length1.Value = 1 / 64 * 25.4
        Part.Update()

        Dim Selection As INFITF.Selection = CATIAV5.ActiveDocument.Selection
        Selection.Clear()
        Dim PlaneYZ As INFITF.AnyObject = OriginElements.PlaneYZ
        Dim PlaneZX As INFITF.AnyObject = OriginElements.PlaneZX
        Selection.Add(PlaneXY)
        Selection.Add(PlaneYZ)
        Selection.Add(PlaneZX)
        Dim VisPropertySet As INFITF.VisPropertySet = Selection.VisProperties
        VisPropertySet.SetShow(INFITF.CatVisPropertyShow.catVisPropertyNoShowAttr)
        Selection.Clear()
        Part.Update()

        Dim NamePartOD As String = BushingOD * 64
        Dim NamePartLength As String = BushingLength * 16
        Dim NamePartID As String = Math.Round(BushingID, 4)
        If NamePartID.Substring(0, 1) = 0 Then
            NamePartID = NamePartID.Substring(1)
            If Len(NamePartID) < 5 Then
                Do While Len(NamePartID) < 5
                    NamePartID &= "0"
                Loop
            End If
        Else
            If Len(NamePartID) < 6 Then
                Do While Len(NamePartID) < 6
                    NamePartID &= "0"
                Loop
            End If
        End If
        Dim Name As String = "P-" & NamePartOD & "-" & NamePartLength & "-" & NamePartID
        Dim RootProduct As ProductStructureTypeLib.Product = CATIAV5.ActiveDocument.Product
        RootProduct.PartNumber = Name
        RootProduct.DescriptionRef = "PRESS FIT BUSHING, " & Math.Round(BushingID, 4) & "in ID X " & Math.Round(BushingOD, 4) & "in OD X " & Math.Round(BushingLength, 4) & "in L"
        RootProduct.Revision = "---"
        RootProduct.Source = ProductStructureTypeLib.CatProductSource.catProductBought
        RootProduct.Definition = "PRESS FIT BUSHING"
        RootProduct.Nomenclature = Name
    End Sub
End Class
