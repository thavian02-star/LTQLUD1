Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing

$dbPath = [System.IO.Path]::GetFullPath((Join-Path $PSScriptRoot "..\QuanLyQuanAn.mdb"))
if (-not (Test-Path $dbPath)) {
    [System.Windows.Forms.MessageBox]::Show("Không tìm thấy file CSDL tại: $dbPath", "Lỗi", "OK", "Error")
    exit
}

$connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=$dbPath;"

# Tạo Form giao diện
$form = New-Object System.Windows.Forms.Form
$form.Text = "Trình Xem Cơ Sở Dữ Liệu Access - Quản Lý Quán Ăn"
$form.Size = New-Object System.Drawing.Size(1000, 600)
$form.StartPosition = "CenterScreen"
$form.Font = New-Object System.Drawing.Font("Segoe UI", 9)

# Panel chứa danh sách bảng
$panelLeft = New-Object System.Windows.Forms.Panel
$panelLeft.Dock = "Left"
$panelLeft.Width = 220
$form.Controls.Add($panelLeft)

$lblTables = New-Object System.Windows.Forms.Label
$lblTables.Text = "DANH SÁCH BẢNG:"
$lblTables.Dock = "Top"
$lblTables.Height = 35
$lblTables.TextAlign = "MiddleLeft"
$lblTables.Font = New-Object System.Drawing.Font("Segoe UI", 9, [System.Drawing.FontStyle]::Bold)
$panelLeft.Controls.Add($lblTables)

$listBox = New-Object System.Windows.Forms.ListBox
$listBox.Dock = "Fill"
$listBox.Font = New-Object System.Drawing.Font("Segoe UI", 10)
$listBox.ItemHeight = 25
$panelLeft.Controls.Add($listBox)

# DataGridView hiển thị dữ liệu
$dgv = New-Object System.Windows.Forms.DataGridView
$dgv.Dock = "Fill"
$dgv.ReadOnly = $true
$dgv.AutoSizeColumnsMode = "AllCells"
$dgv.BackgroundColor = [System.Drawing.Color]::White
$dgv.AlternatingRowsDefaultCellStyle.BackColor = [System.Drawing.Color]::FromArgb(240, 245, 250)
$form.Controls.Add($dgv)

# Lấy danh sách các bảng
$conn = New-Object System.Data.OleDb.OleDbConnection($connStr)
try {
    $conn.Open()
    $schemaTable = $conn.GetOleDbSchemaTable([System.Data.OleDb.OleDbSchemaGuid]::Tables, @($null, $null, $null, "TABLE"))
    foreach ($row in $schemaTable.Rows) {
        $tableName = $row["TABLE_NAME"].ToString()
        if ($tableName -notlike "MSys*") {
            $listBox.Items.Add($tableName) | Out-Null
        }
    }
} catch {
    [System.Windows.Forms.MessageBox]::Show("Lỗi kết nối CSDL: $_", "Lỗi", "OK", "Error")
} finally {
    $conn.Close()
}

# Xử lý sự kiện khi chọn bảng
$listBox.Add_SelectedIndexChanged({
    if ($listBox.SelectedItem) {
        $selectedTable = $listBox.SelectedItem.ToString()
        try {
            $dt = New-Object System.Data.DataTable
            $da = New-Object System.Data.OleDb.OleDbDataAdapter("SELECT * FROM [$selectedTable]", $connStr)
            $da.Fill($dt) | Out-Null
            $dgv.DataSource = $dt
            $form.Text = "Trình Xem CSDL - Đang xem bảng: $selectedTable ($($dt.Rows.Count) dòng)"
        } catch {
            [System.Windows.Forms.MessageBox]::Show("Lỗi tải dữ liệu bảng $selectedTable : $_", "Lỗi", "OK", "Error")
        }
    }
})

if ($listBox.Items.Count -gt 0) {
    $listBox.SelectedIndex = 0
}

[System.Windows.Forms.Application]::Run($form)
