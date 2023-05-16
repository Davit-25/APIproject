using APIproject.Models;

namespace APIproject.Interfaces
{
    public interface IPackageService
    {
        CreatePackageResponse CreatePackage(CreatePackageRequest request);
        GetPackageResponse GetPackage(GetPackageRequest request);   
        UpdatePackageResponse UpdatePackage(UpdatePackageRequest request);
        DeletePackageResponse DeletePackage(DeletePackageRequest request);

    }
}
