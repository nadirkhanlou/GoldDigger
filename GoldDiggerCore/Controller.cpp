#include "Controller.h"

namespace GoldDiggerCore {

	Controller::Controller(const char* path)
		: _map(path)
	{
		_agent = Agent(&_map);
	}
	AgentAction* Controller::ValueIteration(double gamma)
	{
		return _agent.ValueIteration(gamma);
	}
	AgentAction* Controller::PolicyIteration(double gamma)
	{
		return _agent.PolicyIteration(gamma);
	}
	AgentAction Controller::QLearningAct(double gamma)
	{
		return _agent.QLearningAct(gamma);
	}
	int Controller::AgentRandomPosition()
	{
		return _agent.RandomPosition();
	}
	std::pair<int, int> Controller::Size()
	{
		return std::make_pair(_agent.GetOptions().n, _agent.GetOptions().m);
	}
	double** Controller::GetQTable()
	{
		return _agent.GetQ();
	}
	void Controller::PrintQTable()
	{
		_agent.PrintQ();
	}
} // namespace goldDiggerCore
