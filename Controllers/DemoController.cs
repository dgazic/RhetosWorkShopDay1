using Microsoft.AspNetCore.Mvc;
using Rhetos;
using Rhetos.Processing;
using Rhetos.Processing.DefaultCommands;

[Route("Demo/[action]")]
public class DemoController : ControllerBase
{
    private readonly IProcessingEngine processingEngine;
    private readonly IUnitOfWork unitOfWork;

    public DemoController(IRhetosComponent<IProcessingEngine> processingEngine, IRhetosComponent<IUnitOfWork> unitOfWork)
    {
        this.processingEngine = processingEngine.Value;
        this.unitOfWork = unitOfWork.Value;
    }
}