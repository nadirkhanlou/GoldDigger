#pragma once

#include <vector>
#include <fstream>
#include <utility>

namespace GoldDiggerMap {

	class Agent;

	struct Block {
		bool down, left, up, right;		// Determines wether each action is possible in the block
		bool gold;						// Determines whether the block contains gold

		Block()
			: down(0), left(0), up(0), right(0), gold(0)
		{ }

		Block(bool d, bool l, bool u, bool r)
			: down(d), left(l), up(u), right(r), gold(0)
		{ }
	};

	enum class Action { Down, Left, Up, Right, Dig };

	class Map {
	private:
		Block* _map;
		unsigned int _n, _m;
		unsigned int _startPos;

	public:
		Map(const char* path);
		~Map();
		Map(const Map& other);
		Map(Map&& other);
		Map& operator=(const Map& other);
		Map& operator=(Map&& other);

		bool IsActionPossible(unsigned int pos, Action action);
		std::pair<unsigned int, unsigned int> Get2DCoordinate(unsigned int pos) { return std::make_pair(pos % _n, pos / _n); }
		unsigned int GetFlatCoordinate(unsigned int x, unsigned int y) { return y * _n + x; }
	};


} // namespace GoldDiggerMap