#include "Map.h"


namespace GoldDiggerMap {

	Map::Map(const char* path) {
		std::ifstream input(path);

		input >> _n >> _m;

		_map = new Block[_n * _m];

		for (unsigned int i = 0; i < _n * _m; ++i) {
			bool d, l, u, r;
			input >> d >> l >> u >> r;
			_map[i] = Block(d, l, u, r);
		}

		input >> _startPos;
		unsigned int tmp;
		while (input >> tmp) {
			_map[tmp].gold = 1;
			// @TODO: Should I also make this a 'trap' block, e.g. make the other
			// four actions impossible?
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

	bool Map::IsActionPossible(unsigned int pos, Action action) {
		if (action == Action::Dig) return _map[pos].gold;
		else if (action == Action::Down) return _map[pos].down;
		else if (action == Action::Left) return _map[pos].left;
		else if (action == Action::Up) return _map[pos].up;
		else return _map[pos].right;
	}

} // namespace GoldDiggerMap