using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Experiments.Data.Context;
using Experiments.Repositories.Experiments;
using Microsoft.EntityFrameworkCore;

public class ExperimentsRepoBenchmark
{
    private readonly IExperimentsRepository _repo;
    private string deviceToken;

    public ExperimentsRepoBenchmark()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ExperimentsDbContext>();
        optionsBuilder.UseSqlServer("Server=localhost;Database=ColorsExperimentDb;User Id=admin;Password=admin;TrustServerCertificate=true;");
        var dbContextOptions = optionsBuilder.Options;
        var dbContext = new ExperimentsDbContext(dbContextOptions);

        _repo = new SqlExperimentsRepository(dbContext);

        deviceToken = "device1";
    }

    [Benchmark]
    public async Task GetColorForDeviceBenchmark()
    {
        await _repo.GetColorForDevice(deviceToken);
    }

    [Benchmark]
    public async Task GetPriceForDeviceBenchmark()
    {
        await _repo.GetPriceForDevice(deviceToken);
    }

    [Benchmark]
    public async Task GetExperimentResultsBenchmark()
    {
        await _repo.GetExperimentResults("price");
    }
}

class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<ExperimentsRepoBenchmark>();
    }
}