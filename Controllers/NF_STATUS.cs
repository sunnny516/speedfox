namespace MuXunProxy.Controllers
{
    internal enum NF_STATUS
    {
        NF_STATUS_SUCCESS,
        NF_STATUS_FAIL = -1,
        NF_STATUS_INVALID_ENDPOINT_ID = -2,
        NF_STATUS_NOT_INITIALIZED = -3,
        NF_STATUS_IO_ERROR = -4
    }

    public enum NetFilterStatus
    {
        OK,
        Err,
        CertificateError,
        NotFoundNetfilter,
        FileMissing,
        SystemErrNotFoundPath,
        NetFilterConflict,
        const_7
    }

}