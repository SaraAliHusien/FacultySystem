

namespace FacultySystem.Core.Bases
{
    public class ResponseHandler
    {
        #region fields
        //private readonly IStringLocalizer<SharedResource> _localizerString;
        #endregion
        #region Ctors
        //public ResponseHandler(IStringLocalizer<SharedResource> localizerString)
        //{
        //    _localizerString = localizerString;
        //}
        #endregion
        #region Actions
        public ResponseBase<T> Deleted<T>(string message = null)
        {
            return new ResponseBase<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = message ?? "Deleted"
                //_localizerString[SharedResourcesKeys.Deleted]
            };
        }

        public ResponseBase<T> Success<T>(T entity, object Meta = null, string message = null)
        {
            return new ResponseBase<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = message ?? "Success",
                //_localizerString[SharedResourcesKeys.Created],
                Meta = Meta
            };
        }
        public ResponseBase<T> Failed<T>(string message = null)
        {
            return new ResponseBase<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = false,
                Message = message ?? "un error found"
                //_localizerString[SharedResourcesKeys.Deleted]
            };
        }
        public ResponseBase<T> Unauthorized<T>()
        {
            return new ResponseBase<T>()
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
                Succeeded = true,
                Message = "Unauthorized"
                //_localizerString[SharedResourcesKeys.UnAuthorized]
            };
        }
        public ResponseBase<T> BadRequest<T>(string Message = null)
        {
            return new ResponseBase<T>()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = Message ?? "BadRequest"
                //_localizerString[SharedResourcesKeys.BadRequest]
            };
        }

        public ResponseBase<T> NotFound<T>(string message = null)
        {
            return new ResponseBase<T>()
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message ?? "NotFound"
                //_localizerString[SharedResourcesKeys.NotFound]
            };
        }

        public ResponseBase<T> Created<T>(T entity, object Meta = null)
        {
            return new ResponseBase<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.Created,
                Succeeded = true,
                Message = "Created",//_localizerString[SharedResourcesKeys.Created],
                Meta = Meta
            };
        }
        #endregion
    }


}
