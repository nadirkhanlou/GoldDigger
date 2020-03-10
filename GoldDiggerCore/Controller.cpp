#include "Controller.h"

namespace GoldDiggerCore {

	Controller::Controller(const char* path)
		: _map(path)
	{
		_agent = Agent(&_map);
	}
} // namespace goldDiggerCore
