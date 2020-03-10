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
	std::pair<int, int> Controller::Size()
	{
		return std::make_pair(_agent.GetOption().n, _agent.GetOption().m);
	}
} // namespace goldDiggerCore
