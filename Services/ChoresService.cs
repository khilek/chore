
namespace chore.Services;

public class ChoresService
{
  private readonly ChoresRepository _repository;

  public ChoresService(ChoresRepository repository)
  {
    _repository = repository;
  }



  internal List<Chore> GetAllChores()
  {
    List<Chore> chores = _repository.GetAllChores();
    return chores;
  }

  internal Chore GetChoreById(int choreId)
  {
    Chore chore = _repository.GetChoreById(choreId);
    if (chore == null)
    {
      throw new Exception($"Invalid id: {choreId}");
    }
    return chore;
  }

  internal Chore CreateChore(Chore choreData)
  {
    Chore chore = _repository.CreateChore(choreData);
    return chore;
  }

  internal string ClearChore(int choreId)
  {
    Chore ChoreToClear = GetChoreById(choreId);

    _repository.ClearChore(choreId);

    return $"{ChoreToClear.Name} has been cleared off the chore list";
  }

  // internal Chore UpdateChore(Chore choreData, int choreId)
  // {
  //    Chore ChoreToUpdate = GetChoreById(choreId);
  //     choreData.Id = choreId;

  //    _repository.UpdateChore(choreData);

  //    return 
  // }
}