
#include <iostream>
#include <map>

using namespace std;

	static class Figures
	{
		public:static double Line(double angleCoefficient, double x, double upSize)
		{
			return  angleCoefficient * x + upSize;
		}

		public:static double BottomHalfCircle(double radius, double x, double middleX, double middleY)
		{
			return -sqrt(pow(radius, 2) - pow((x - middleX), 2)) + middleY;

		}
	};

	static class Drawer
	{
		map <double, double>* Draw(double step)
		{
			auto* res = new map<double, double>();

			for (double x = -10; x <= 3; x += step)
			{
				res->insert(x, GetValue(x));
			}

			return res;
		}

		double GetValue(double x)
		{
			if (x >= -10 && x <= -6)
				return Figures::BottomHalfCircle(2, x, -8, 2);
			if (x > -6 && x <= -4)
				return Figures::Line(0, x, 2);
			if (x > -4 && x <= 2)
				return Figures::Line(-((double)1 / (double)2), x, 0);
			if (x > 2 && x <= 3)
				return Figures::Line((double)1, x, -3);

			return 0;
		}
	};

	int main()
	{
		auto* drawer = new Drawer();
		for (auto const& value : drawer.Draw(1))
				{
			cout << value.Key : val.Value};
		}
		
	}
