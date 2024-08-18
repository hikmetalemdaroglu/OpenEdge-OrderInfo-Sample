' OpenEdge proxy support classes
Imports Progress.Open4GL.Proxy
' OpenEdge Holder classes
Imports Progress.Open4GL
' OpenEdge Exception classes
Imports Progress.Open4GL.Exceptions
' Proxy classes
Imports OrderProxy

Public Class Demo
    Inherits System.Windows.Forms.Form

    ' Declare the  proxy objects
    Dim m_conn As Connection = Nothing
    Dim m_order As OrderInfo = Nothing
    Dim m_custOrder As CustomerOrder = Nothing
    Dim m_custOrderDetails As StrongTypesNS.OrderDetailsDataTable = Nothing
    Dim m_custNum As Integer = -1

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents btnDisconnect As System.Windows.Forms.Button
    Friend WithEvents txtCustNum As System.Windows.Forms.TextBox
    Friend WithEvents btnFindByNum As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblCustName As System.Windows.Forms.Label
    Friend WithEvents txtURL As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grpCustByNum As System.Windows.Forms.GroupBox
    Friend WithEvents grdDetails As System.Windows.Forms.DataGrid
    Friend WithEvents icoConnected As System.Windows.Forms.PictureBox
    Friend WithEvents icoDisconnected As System.Windows.Forms.PictureBox
    Friend WithEvents btnUpdateOrders As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Demo))
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.btnDisconnect = New System.Windows.Forms.Button()
        Me.grpCustByNum = New System.Windows.Forms.GroupBox()
        Me.btnUpdateOrders = New System.Windows.Forms.Button()
        Me.grdDetails = New System.Windows.Forms.DataGrid()
        Me.lblCustName = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCustNum = New System.Windows.Forms.TextBox()
        Me.btnFindByNum = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtURL = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.icoConnected = New System.Windows.Forms.PictureBox()
        Me.icoDisconnected = New System.Windows.Forms.PictureBox()
        Me.grpCustByNum.SuspendLayout()
        CType(Me.grdDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnConnect
        '
        Me.btnConnect.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConnect.Image = CType(resources.GetObject("btnConnect.Image"), System.Drawing.Bitmap)
        Me.btnConnect.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnConnect.Location = New System.Drawing.Point(100, 53)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(107, 28)
        Me.btnConnect.TabIndex = 0
        Me.btnConnect.Text = "        &Connect         "
        '
        'btnDisconnect
        '
        Me.btnDisconnect.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDisconnect.Location = New System.Drawing.Point(322, 54)
        Me.btnDisconnect.Name = "btnDisconnect"
        Me.btnDisconnect.Size = New System.Drawing.Size(105, 28)
        Me.btnDisconnect.TabIndex = 1
        Me.btnDisconnect.Text = "&Disconnect"
        '
        'grpCustByNum
        '
        Me.grpCustByNum.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnUpdateOrders, Me.grdDetails, Me.lblCustName, Me.Label1, Me.txtCustNum, Me.btnFindByNum, Me.Label2})
        Me.grpCustByNum.Enabled = False
        Me.grpCustByNum.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCustByNum.Location = New System.Drawing.Point(6, 101)
        Me.grpCustByNum.Name = "grpCustByNum"
        Me.grpCustByNum.Size = New System.Drawing.Size(566, 404)
        Me.grpCustByNum.TabIndex = 2
        Me.grpCustByNum.TabStop = False
        Me.grpCustByNum.Text = "Find Customer By Number"
        '
        'btnUpdateOrders
        '
        Me.btnUpdateOrders.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateOrders.Image = CType(resources.GetObject("btnUpdateOrders.Image"), System.Drawing.Bitmap)
        Me.btnUpdateOrders.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnUpdateOrders.Location = New System.Drawing.Point(441, 31)
        Me.btnUpdateOrders.Name = "btnUpdateOrders"
        Me.btnUpdateOrders.Size = New System.Drawing.Size(107, 27)
        Me.btnUpdateOrders.TabIndex = 14
        Me.btnUpdateOrders.Text = "      &Update"
        '
        'grdDetails
        '
        Me.grdDetails.CaptionText = "Customer Orders"
        Me.grdDetails.DataMember = ""
        Me.grdDetails.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDetails.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdDetails.Location = New System.Drawing.Point(14, 96)
        Me.grdDetails.Name = "grdDetails"
        Me.grdDetails.Size = New System.Drawing.Size(544, 298)
        Me.grdDetails.TabIndex = 13
        '
        'lblCustName
        '
        Me.lblCustName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustName.Location = New System.Drawing.Point(151, 62)
        Me.lblCustName.Name = "lblCustName"
        Me.lblCustName.Size = New System.Drawing.Size(151, 21)
        Me.lblCustName.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 24)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Customer Number:"
        '
        'txtCustNum
        '
        Me.txtCustNum.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustNum.Location = New System.Drawing.Point(151, 37)
        Me.txtCustNum.Name = "txtCustNum"
        Me.txtCustNum.Size = New System.Drawing.Size(73, 22)
        Me.txtCustNum.TabIndex = 5
        Me.txtCustNum.Text = ""
        '
        'btnFindByNum
        '
        Me.btnFindByNum.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindByNum.Image = CType(resources.GetObject("btnFindByNum.Image"), System.Drawing.Bitmap)
        Me.btnFindByNum.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFindByNum.Location = New System.Drawing.Point(315, 30)
        Me.btnFindByNum.Name = "btnFindByNum"
        Me.btnFindByNum.Size = New System.Drawing.Size(107, 27)
        Me.btnFindByNum.TabIndex = 6
        Me.btnFindByNum.Text = "      &Search"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 21)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Customer Name:"
        '
        'txtURL
        '
        Me.txtURL.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtURL.Location = New System.Drawing.Point(98, 21)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.Size = New System.Drawing.Size(329, 22)
        Me.txtURL.TabIndex = 10
        Me.txtURL.Text = "AppServer://localhost:5162/AppSports2000"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 23)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "AppServer:"
        '
        'icoConnected
        '
        Me.icoConnected.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.icoConnected.Image = CType(resources.GetObject("icoConnected.Image"), System.Drawing.Bitmap)
        Me.icoConnected.Location = New System.Drawing.Point(458, 23)
        Me.icoConnected.Name = "icoConnected"
        Me.icoConnected.Size = New System.Drawing.Size(49, 46)
        Me.icoConnected.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.icoConnected.TabIndex = 0
        Me.icoConnected.TabStop = False
        Me.icoConnected.Visible = False
        '
        'icoDisconnected
        '
        Me.icoDisconnected.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.icoDisconnected.Image = CType(resources.GetObject("icoDisconnected.Image"), System.Drawing.Bitmap)
        Me.icoDisconnected.Location = New System.Drawing.Point(458, 23)
        Me.icoDisconnected.Name = "icoDisconnected"
        Me.icoDisconnected.Size = New System.Drawing.Size(49, 46)
        Me.icoDisconnected.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.icoDisconnected.TabIndex = 9
        Me.icoDisconnected.TabStop = False
        '
        'Demo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 15)
        Me.ClientSize = New System.Drawing.Size(578, 510)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.txtURL, Me.grpCustByNum, Me.btnDisconnect, Me.btnConnect, Me.icoDisconnected, Me.icoConnected})
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "Demo"
        Me.Text = "OpenEdge .NET Integration Demo"
        Me.grpCustByNum.ResumeLayout(False)
        CType(Me.grdDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Initialize some UI values
        InitUI()

    End Sub


    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        Try
            ' Instantiate the proxy objects and connect
            m_conn = New Connection(txtURL.Text, "", "", "")
            m_order = New OrderInfo(m_conn)

            ' Show the user we're connected
            InitConnectUI()


        Catch conEx As Exception
            MsgBox("Unable to connect to service: " + conEx.Message, MsgBoxStyle.Critical, "Connection Error")

        End Try

    End Sub


    Private Sub btnFindByNum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindByNum.Click

        ' This finds a Customer Name from the Customer Number
        Dim custNum As IntHolder = New IntHolder()
        Dim custName As String = Nothing

        Try
            ' Send a request to the AppServer to get the Customer Name
            m_custNum = CInt(txtCustNum.Text)
            custNum.Value = m_custNum
            m_order.FindCustomerByNum(custNum, custName)
            If custName <> Nothing Then
                lblCustName.Text = custName

                ' First Tell the AppServer to release the Persistent Proc
                ' from the last cust num
                If Not (m_custOrder Is Nothing) Then
                    m_custOrder.Dispose()
                End If

                ' Run CustomerOrder.p on the AppServer
                m_custOrder = m_order.CreatePO_CustomerOrder(custNum)
                m_custOrder.GetOrderDetails(m_custOrderDetails)
                ShowDetails()

            Else
                MsgBox("There is no customer with that Customer Number", MsgBoxStyle.Exclamation, "Find Customer By Number Failed")
                lblCustName.Text = ""

            End If

        Catch procEx As Exception
            MsgBox("Unable to execute procedure: " + procEx.Message, MsgBoxStyle.Critical, "Connection Error")
        End Try
    End Sub

    Private Sub btnUpdateOrders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateOrders.Click
        Dim custOrderRow As StrongTypesNS.OrderDetailsRow = Nothing
        Dim i As Integer
        Dim temp As Integer

        Try
            If txtCustNum.Text.Length > 0 Then
                temp = CInt(txtCustNum.Text)
            End If
            If m_custNum = temp Then

                ' Update the data and send it back
                For i = 0 To m_custOrderDetails.Rows.Count() - 1 Step 1
                    custOrderRow = m_custOrderDetails.Rows.Item(i)
                    custOrderRow.OrderDate = custOrderRow.OrderDate.AddYears(10)
                    custOrderRow.ShipDate = System.DateTime.Now
                Next
                ' Call the proecure on the AppServer with the updated data
                m_custOrder.UpdateOrderDetails(m_custOrderDetails)
            Else
                MessageBox.Show("Please Search for this customer before updating", "OpenEdge Demo - Error", MessageBoxButtons.OK)
            End If

        Catch procEx As Exception
            MsgBox("Unable to execute procedure: " + procEx.Message, MsgBoxStyle.Critical, "Connection Error")
        End Try
    End Sub

    Private Sub btnDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisconnect.Click

        ' It is important to release any objects we have created when
        ' running Session Managed. Otherwise, we will leave zombie 
        ' processes on the WSA that will require restarting of the
        ' servlet engine to release them.
        Try
            ' Tell the AppServer to release the Persistent Proc
            If Not (m_custOrder Is Nothing) Then
                m_custOrder.Dispose()
            End If
            m_order.Dispose()
            btnDisconnect.Enabled = False
            btnConnect.Enabled = True
            icoDisconnected.Visible = True
            icoConnected.Visible = False
            grpCustByNum.Enabled = False
            txtURL.ReadOnly = False
            grdDetails.DataSource = Nothing
            btnConnect.Focus()

        Catch relEx As Exception
            MsgBox("Unable to connect to service: " + relEx.Message, MsgBoxStyle.Critical, "Release Error")

        End Try

    End Sub


    Private Sub txtURL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtURL.KeyPress

        ' This handles when the user presses ENTER in the URL text
        ' box and treats it as a Connect.
        If e.KeyChar() = Chr(13) Then
            btnConnect.Focus()
            Me.btnConnect_Click(Me.btnConnect, Nothing)
            e.Handled = True
        End If

    End Sub

    Private Sub Main_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        ' Check to make sure we have released our connection so that
        ' we do not create zombie processes on the WSA
        If btnDisconnect.Enabled Then
            If Not (m_custOrder Is Nothing) Then
                m_custOrder.Dispose()
            End If
            m_order.Dispose()
        End If
    End Sub

    Private Sub grpCustByNum_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grpCustByNum.EnabledChanged

        If grpCustByNum.Enabled = False Then
            lblCustName.Text = ""
            txtCustNum.Text = ""
        End If
    End Sub

    Public Sub ShowDetails()
        grdDetails.DataSource = m_custOrderDetails

    End Sub

    Private Sub InitUI()
        btnDisconnect.Enabled = False
        btnConnect.Enabled = True
        icoDisconnected.Visible = True
        icoConnected.Visible = False
    End Sub

    Private Sub InitConnectUI()
        btnDisconnect.Enabled = True
        btnConnect.Enabled = False
        icoDisconnected.Visible = False
        icoConnected.Visible = True
        grpCustByNum.Enabled = True
        txtURL.ReadOnly = True
        txtCustNum.Focus()
    End Sub

    Private Sub InitGrid()
        Dim gs As DataGridTableStyle = New DataGridTableStyle()
        gs.MappingName = m_order.GetType().Name

        Dim cs As DataGridTextBoxColumn = New DataGridTextBoxColumn()
        cs.MappingName = "OrderNum"
        cs.HeaderText = "Order Number"
        cs.Alignment = HorizontalAlignment.Center
        cs.Width = 50
        gs.GridColumnStyles.Add(cs)

        cs = New DataGridTextBoxColumn()
        cs.MappingName = "SalesRep"
        cs.HeaderText = "Sales Rep"
        cs.Alignment = HorizontalAlignment.Center
        cs.Width = 60
        gs.GridColumnStyles.Add(cs)

        cs = New DataGridTextBoxColumn()
        cs.MappingName = "OrderDate"
        cs.HeaderText = "Order Date"
        cs.Alignment = HorizontalAlignment.Right
        cs.Width = 80
        gs.GridColumnStyles.Add(cs)

        cs = New DataGridTextBoxColumn()
        cs.MappingName = "ShipDate"
        cs.HeaderText = "Ship Date"
        cs.Alignment = HorizontalAlignment.Right
        cs.Width = 100
        gs.GridColumnStyles.Add(cs)

        cs = New DataGridTextBoxColumn()
        cs.MappingName = "TotalDollars"
        cs.HeaderText = "Total $$$"
        cs.Alignment = HorizontalAlignment.Right
        cs.Width = 100
        gs.GridColumnStyles.Add(cs)

        cs = New DataGridTextBoxColumn()
        cs.MappingName = "OrderStatus"
        cs.HeaderText = "Status"
        cs.Alignment = HorizontalAlignment.Right
        cs.Width = 100
        gs.GridColumnStyles.Add(cs)

        grdDetails.TableStyles.Add(gs)

    End Sub


End Class
