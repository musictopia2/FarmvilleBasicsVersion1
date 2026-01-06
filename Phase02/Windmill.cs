namespace Phase02;

internal class Windmill
{
    private readonly Inventory _inventory;
    private readonly ConcurrentQueue<CraftingJob> _queue = new();
    private readonly List<CraftingJob> _runningJobs = new();
    private readonly int _maxConcurrentJobs = 2;

    public Windmill(Inventory inventory)
    {
        _inventory = inventory;
        Task.Run(ProcessQueue);
    }

    public bool CanProcess(EnumJobType jobType)
    {
        // Check if queue + running jobs is at max capacity
        if (_queue.Count + _runningJobs.Count >= _maxConcurrentJobs)
        {
            return false;
        }

        return _inventory.CanCraft(jobType);
    }

    public void Enqueue(EnumJobType jobType)
    {
        if (!_inventory.CanCraft(jobType))
        {
            AnsiConsole.WriteLine("Not Enough Resources", cc1.Red);
            return;
        }

        if (_queue.Count + _runningJobs.Count >= _maxConcurrentJobs)
        {
            AnsiConsole.WriteLine("Windmill is busy. Try again later.", cc1.Orange);
            return;
        }

        _inventory.Consume(jobType);
        var job = new CraftingJob(jobType);
        _queue.Enqueue(job);
        AnsiConsole.WriteLine($"{job} added to queue.", cc1.LimeGreen);
    }

    private async Task ProcessQueue()
    {
        while (true)
        {
            // Start jobs if we have slots
            while (_runningJobs.Count < _maxConcurrentJobs && _queue.TryDequeue(out var job))
            {
                _runningJobs.Add(job);
                _ = ProcessJobAsync(job); // fire-and-forget each job
            }

            await Task.Delay(200);
        }
    }

    private async Task ProcessJobAsync(CraftingJob job)
    {
        AnsiConsole.WriteLine($"Started crafting {job.Type} ({job.DurationSeconds}s)", cc1.LightBlue);
        await Task.Delay(job.DurationSeconds * 1000);
        _inventory.Produce(job.Type);
        AnsiConsole.WriteLine($"{job.Type} completed!", cc1.LimeGreen);
        _runningJobs.Remove(job); // remove from running jobs
    }

    public void PrintQueueSpectre()
    {
        if (_queue.IsEmpty && _runningJobs.Count == 0)
        {
            AnsiConsole.WriteLine("Queue is empty.", cc1.Gray);
            return;
        }

        ManualTable table = new();
        table.AddColumn("Queued Jobs");

        foreach (var job in _queue)
        {
            table.AddRow(job.ToString()!);
        }

        foreach (var job in _runningJobs)
        {
            string text = $"{job} (Running)";
            table.AddRow(text!);
        }

        AnsiConsole.Write(table);
    }
}