Public Class Form1
    Private monto As Double
    Private Sub activarcontroles()
        Txt_Cliente.Enabled = False
        Txt_Monto.Enabled = False
        Btn_AbrirCuenta.Enabled = False
        Btn_Retiro.Enabled = True
        Btn_Deposito.Enabled = True

    End Sub
    Private Sub desactivarontroles()
        Txt_Cliente.Enabled = True
        Txt_Monto.Enabled = True
        Btn_AbrirCuenta.Enabled = True
        Btn_Retiro.Enabled = False
        Btn_Deposito.Enabled = False

    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        desactivarontroles()

    End Sub

    Private Sub Btn_AbrirCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_AbrirCuenta.Click
        Dim cliente As String
        cliente = Txt_Cliente.Text
        monto = Val(Txt_Monto.Text)
        If (monto) >= 0 Then
            Call activarcontroles()
        Else
            MessageBox.Show("el monto no puede ser menor que cero", "Gestion de ahorros", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If
    End Sub

    Private Sub Btn_Deposito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Deposito.Click
        Dim deposito As Double
        deposito = leer("depositar")
        monto = monto + deposito
        Lst_Depositos.Items.Add(deposito)
        Call mostrar()

    End Sub
    Private Function leer(ByVal mensaje As String) As Double
        Dim cantidad As Double
        cantidad = InputBox("Ingrese monto a " + mensaje, "Gestion de Ahorros", "0", 100, 0)
        Return cantidad
    End Function
    Private Sub mostrar()
        Txt_Saldo.Text = monto

    End Sub

    Private Sub Btn_Retiro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Retiro.Click
        Dim retiro As Double
        retiro = leer("Retirar")
        If (retiro <= monto) Then
            monto = monto - retiro
            Lst_Retiros.Items.Add(retiro)
            Call mostrar()
        Else
            MessageBox.Show("No  se puede retirar un monto mayor AL MONTO ACTUAL", "Gestion de Ahorros", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Btn_Limpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Limpiar.Click
        Call desactivarontroles()
        Lst_Depositos.Items.Clear()
        Lst_Retiros.Items.Clear()
        Txt_Monto.Clear()
        Txt_Cliente.Clear()
        Txt_Saldo.Clear()

    End Sub
End Class
