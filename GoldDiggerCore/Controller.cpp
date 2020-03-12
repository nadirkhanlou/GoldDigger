#include "Controller.h"

namespace GoldDiggerCore {

	Controller::Controller(const char* path)
		: _map(path)
	{
		_agent = Agent(&_map);
	}
	AgentAction* Controller::ValueIteration()
	{
		return _agent.ValueIteration();
	}
	AgentAction* Controller::PolicyIteration()
	{
		return _agent.PolicyIteration();
	}
	AgentAction Controller::QLearningAct()
	{
		return _agent.QLearningAct();
	}
	std::pair<int, int> Controller::Size()
	{
		return std::make_pair(_agent.GetOptions().n, _agent.GetOptions().m);
	}
} // namespace goldDiggerCore
