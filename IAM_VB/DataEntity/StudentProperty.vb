Public Class StudentProperty
    'Property Student

    Private s_studentid As Integer
    Private s_code As String
    Private s_nis As String
    Private s_smarcardid As Integer
    Private s_un_number As String
    Private s_name As String
    Private s_birthday As String
    Private s_sex As String
    Private s_religion As String
    Private s_blodgroup As String
    Private s_address As String
    Private s_phone As String
    Private s_email As String
    Private s_password As String
    Private s_parentid As Integer
    Private s_dormitory_id As Integer
    Private s_transport_id As Integer
    Private s_dormitory_room_number As String
    Private s_authentication_key As String
    Private s_finger_id As Integer
    Private s_finger_data As String
    Private s_userlevel As Integer
    Private s_log_time As String
    Private s_data As String
    Private s_date_login As String
    Private s_time_login As String
    Private s_date_logout As String
    Private s_time_logout As String
    Private s_login_status As String
    Private s_logout_status As String
    Private s_id As Integer
    Private s_about As String
    Private s_active As Integer
    Private s_avatar_id As Integer
    Private s_cover_id As Integer
    Private s_cover_position As Integer
    Private s_email_verification_key As String
    Private s_email_verified As Integer
    Private s_language As String
    Private s_last_logged As Integer
    Private s_time As Integer
    Private s_timestamp As String
    Private s_timezone As String
    Private s_type As String
    Private s_username As String
    Private s_verified As Integer
    Private s_year As String
    Private s_class_id As Integer
    Private s_section_id As Integer
    Private s_class_routine_id As Integer
    Private s_image As String

    
    Public Property student_id As Integer
        Get
            'Get : hanya ijinkan akses data
            Return s_studentid
        End Get
        Set(ByVal value As Integer)
            s_studentid = value
        End Set
    End Property
    Public Property id As Integer
        Get
            'Get : hanya ijinkan akses data
            Return s_id
        End Get
        Set(ByVal value As Integer)
            s_id = value
        End Set
    End Property

    Public Property student_code As String
        Get
            'Get : hanya ijinkan akses data
            Return s_code
        End Get
        Set(ByVal value As String)
            s_code = value
        End Set
    End Property
    Public Property nisn As String
        Get
            'Get : hanya ijinkan akses data
            Return s_nis
        End Get
        Set(ByVal value As String)
            s_nis = value
        End Set
    End Property
    Public Property smartcard_id As Integer
        Get
            'Get : hanya ijinkan akses data
            Return s_smarcardid
        End Get
        Set(ByVal value As Integer)
            s_smarcardid = value
        End Set
    End Property
    Public Property name As String
        Get
            'Get : hanya ijinkan akses data
            Return s_name
        End Get
        Set(ByVal value As String)
            s_name = value
        End Set
    End Property

    Public Property class_id As Integer
        Get
            'Get : hanya ijinkan akses data
            Return s_class_id
        End Get
        Set(ByVal value As Integer)
            s_class_id = value
        End Set
    End Property


    Public Property password As String
        Get
            'Get : hanya ijinkan akses data
            Return s_password
        End Get
        Set(ByVal value As String)
            s_password = value
        End Set
    End Property
    Public Property username As String
        Get
            'Get : hanya ijinkan akses data
            Return s_username
        End Get
        Set(ByVal value As String)
            s_username = value
        End Set
    End Property
    Public Property section_id As Integer
        Get
            'Get : hanya ijinkan akses data
            Return s_section_id
        End Get
        Set(ByVal value As Integer)
            s_section_id = value
        End Set
    End Property
    Public Property class_routine_id As Integer
        Get
            'Get : hanya ijinkan akses data
            Return s_class_routine_id
        End Get
        Set(ByVal value As Integer)
            s_class_routine_id = value
        End Set
    End Property

    Public Property year As String
        Get
            'Get : hanya ijinkan akses data
            Return s_year
        End Get
        Set(ByVal value As String)
            s_year = value
        End Set
    End Property
    Public Property images As String
        Get

            Return s_image
        End Get
        Set(ByVal value As String)
            s_image = value
        End Set
    End Property
End Class
