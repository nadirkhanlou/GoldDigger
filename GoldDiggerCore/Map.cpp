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

			MarkAsAccessible(tmp);
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

	std::pair<unsigned int, unsigned int> Map::Get2DCoordinate(unsigned int pos) {
		assert(pos < _n * _m);
		return std::make_pair(pos % _n, pos / _n);
	}

	unsigned int Map::GetFlatCoordinate(unsigned int x, unsigned int y) {
		assert(pos < _n * _m);
		return y * _n + x;
	}

	unsigned int Map::NextPosition(unsigned int pos, AgentAction action) {
		assert(pos < _n * _m);
		if (action == AgentAction::Up && _map[pos].up)
			return pos - 1;
		else if (action == AgentAction::Right && _map[pos].right)
			return pos + _n;
		else if (action == AgentAction::Down && _map[pos].down)
			return pos + 1;
		else if (action == AgentAction::Left && _map[pos].left)
			return pos - _n;
		else				// action is not possible
			return pos;
	}

	int Map::ActionReward(unsigned int pos, AgentAction action) {
		assert(pPos < _n * _m);
		if (_map[NextPosition(pos, action)].gold)
			return GOAL_SCORE;
		else
			return 0;
	}

	void Map::MarkAsAccessible(unsigned int pos)
	{
		_goldAccessPartition[pos] = true;
		if (_map[pos].up && !_goldAccessPartition[pos - 1])
			MarkAsAccessible(pos - 1);
		if (_map[pos].down && !_goldAccessPartition[pos + 1])
			MarkAsAccessible(pos + 1);
		if (_map[pos].right && !_goldAccessPartition[pos + _m])
			MarkAsAccessible(pos + _m);
		if (_map[pos].left && !_goldAccessPartition[pos - _m])
			MarkAsAccessible(pos - _m);
	}

} // namespace GoldDiggerCore
