

import PropTypes from 'prop-types';
import ArrowPathIcon from '@heroicons/react/24/solid/ArrowPathIcon';
import ArrowRightIcon from '@heroicons/react/24/solid/ArrowRightIcon';
import {
  Button,
  Card,
  CardActions,
  CardContent,
  CardHeader,
  Divider,
  Stack,
  SvgIcon,
  Typography
} from '@mui/material';
import { alpha, useTheme } from '@mui/material/styles';
import { Chart } from 'src/components/chart';
import PlusIcon from '@heroicons/react/24/solid/PlusIcon';
import millify from 'millify';

const useChartOptions = () => {
  const theme = useTheme();

  return {
    chart: {
      background: 'transparent',
      stacked: false,
      toolbar: {
        show: false
      }
    },
    colors: [theme.palette.primary.main, alpha(theme.palette.primary.main, 0.25)],
    dataLabels: {
      enabled: false
    },
    fill: {
      opacity: 1,
      type: 'solid'
    },
    grid: {
      borderColor: theme.palette.divider,
      strokeDashArray: 2,
      xaxis: {
        lines: {
          show: false
        }
      },
      yaxis: {
        lines: {
          show: true
        }
      }
    },
    legend: {
      show: false
    },
    plotOptions: {
      bar: {
        columnWidth: '40px'
      }
    },
    stroke: {
      colors: ['transparent'],
      show: true,
      width: 2
    },
    theme: {
      mode: theme.palette.mode
    },
    xaxis: {
      axisBorder: {
        color: theme.palette.divider,
        show: true
      },
      axisTicks: {
        color: theme.palette.divider,
        show: true
      },
      categories: [
        'Jan',
        'Feb',
        'Mar',
        'Apr',
        'May',
        'Jun',
        'Jul',
        'Aug',
        'Sep',
        'Oct',
        'Nov',
        'Dec'
      ],
      labels: {
        offsetY: 5,
        style: {
          colors: theme.palette.text.secondary
        }
      }
    },
    yaxis: {
      labels: {
        formatter: (value) => (value > 0 ? `${value}K` : `${value}`),
        offsetX: -10,
        style: {
          colors: theme.palette.text.secondary
        }
      }
    }
  };
};

export const OverviewListenerGender = (props) => {
  const { fProportion, mProportion } = props;
  const chartOptions = useChartOptions();

  return (
    <div style={{ display: 'flex', flexDirection: 'column', flex: 1 }}>
      <Stack
        sx={{ marginTop: '40px' }}
        direction="row"
        justifyContent="space-between"
        spacing={4}>
        <Stack direction="column">
          <Typography variant="h5">
            {`Listener's Gender`}
          </Typography>
          <Typography
            sx={{
              fontSize: '0.875rem',
              fontWeight: 400,
              marginTop: '5px'
            }}
            variant="subtitle2">
            {`Listener in last 28 days`}
          </Typography>
        </Stack>
      </Stack>
      <Chart
        height={500}
        options={{
          ...chartOptions,
          dataLabels: {
            enabled: true
          },
          stroke: {
            curve: 'smooth',
          },
          labels: ['Female', 'Male',],
          legend: {
            position: 'bottom',
            offsetY: 0,
            height: 60,
          }
        }}
        series={[fProportion, mProportion]}
        type="donut"
        width="100%"
      />
    </div>
  );
};

OverviewListenerGender.protoTypes = {
  fProportion: PropTypes.number.isRequired,
  mProportion: PropTypes.number.isRequired,
  sx: PropTypes.object
};
