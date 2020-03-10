#include "Map.h"

namespace GoldDiggerCore {

	Map::Map(const char* path) {
		std::ifstream input(path);

		input >> _n >> _m;

		_map = new Block[_n * _m];

		bool u, r, d, l;
		for (unsigned int i = 0; i < _n * _m; ++i) {
			input >> u >> r >> d >> l;
			_map[i] = Block(u, r, d, l);
		}

		input >> _startPos;
		--_startPos;	// Because the positions in input file are 1-based
		unsigned int tmp;
		while (input >> tmp) {
			--tmp;		// Because the positions in input file are 1-based
			_map[tmp].gold = 1;
			// @TODO: Should I also make this a 'trap' block, e.g. make the other
			// four actions impossible?
			_map[tmp].up = _map[tmp].right = _map[tmp].down = _map[tmp].left = 0;
		}
	}

	Map::~Map() {
		delete[] _map;
	}

	Map::Map(const Map& other)
		: _n(other._n),
		_m(other._m),
		_startPos(other._startPos) {
		_map = new Block[_n * _m];
		for (unsigned int i = 0; i < _n * _m; ++i)
			_map[i] = other._map[i];
	}

	Map::Map(Map&& other)
		: _n(other._n),
		_m(other._m),
		_startPos(other._startPos) {
		_map = other._map;
		other._map = nullptr;
	}

	Map& Map::operator=(const Map& other) {
		_n = other._n;
		_m = other._m;
		_startPos = other._startPos;
		delete[] _map;
		_map = new Block[_n * _m];
		for (unsigned int i = 0; i < _n * _m; ++i)
			_map[i] = other._map[i];

		return *this;
	}

	Map& Map::operator=(Map&& other) {
		_n = other._n;
		_m = other._m;
		_startPos = other._startPos;
		delete[] _map;
		_map = other._map;
		other._map = nullptr;

		return *this;
	}

	Block Map::Sense(unsigned int pos) {
		assert(pos < _n * _m);
		return _map[pos];
	}

	bool Map::IsActionPossible(unsigned int pos, AgentAction action) {
		assert(pos < _n * _m);
		if (action == AgentAction::Dig) return _map[pos].gold;
		else if (action == AgentAction::Up) return _map[pos].up;
		else if (action == AgentAction::Right) return _map[pos].right;
		else if (action == AgentAction::Down) return _map[pos].down;
		else return _map[pos].left;
	}

	std::pair<unsigned int, unsigned int> Map::Get2DCoordinate(unsigned int pos) {
		assert(pos < _n * _m);
		return std::make_pair(pos % _n, pos / _n);
	}

	unsigned int Map::GetFlatCoordinate(unsigned int x, unsigned int y) {
		assert(pos < _n * _m);
		return y * _n + x;
	}

	std::pair<unsigned int, int> Map::ActionResult(unsigned int pos, AgentAction action) {
		assert(pos < _n * _m);
		assert(IsActionPossible(pos, action));
		if (action == AgentAction::Dig)
			return std::make_pair(pos, GOAL_SCORE);
		else if (action == AgentAction::Up)
			return std::make_pair(pos - 1, 0);
		else if (action == AgentAction::Right)
			return std::make_pair(pos + _n, 0);
		else if (action == AgentAction::Down)
			return std::make_pair(pos + 1, 0);
		else if (action == AgentAction::Left)
			return std::make_pair(pos - _n, 0);
	}

	unsigned int Map::NextPosition(unsigned int pos, AgentAction action) {
		assert(Pos < _n * _m);
		assert(IsActionPossible(pos, action));
		if (action == AgentAction::Dig)
			return pos;
		else if (action == AgentAction::Up)
			return pos - 1;
		else if (action == AgentAction::Right)
			return pos + _n;
		else if (action == AgentAction::Down)
			return pos + 1;
		else // action = Left
			return pos - _n;
	}

	int Map::ActionReward(unsigned int pos, AgentAction action) {
		assert(pPos < _n * _m);
		assert(IsActionPossible(pos, action));
		if (action == AgentAction::Dig && _map[pos].gold)
			return GOAL_SCORE;
		else
			return 0;
	}

} // namespace GoldDiggerCore
