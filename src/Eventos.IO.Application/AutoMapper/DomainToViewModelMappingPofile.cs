using AutoMapper;
using Eventos.IO.Application.ViewModels;
using Eventos.IO.Domain.Eventos;
using Eventos.IO.Domain.Organizadores;

public class DomainToViewModelMappingPofile : Profile
{
    public DomainToViewModelMappingPofile()
    {
        CreateMap<Evento, EventoViewModel>();
        CreateMap<Endereco, EnderecoViewModel>();
        CreateMap<Categoria, CategoriaViewModel>();
        CreateMap<Organizador, OrganizadorViewModel>();
    }
}
