

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

export const OverviewListenerInPeriod = (props) => {
  const { chartSeries, listeners } = props;
  const chartOptions = useChartOptions();

  return (
    <Stack direction="column">
      <Stack
        sx={{ marginTop: '40px' }}
        direction="row"
        justifyContent="space-between"
        spacing={4}>
        <Stack direction="column">
          <Typography variant="h5">
            {millify(listeners.count)} Listeners
          </Typography>
          <Typography
            sx={{
              fontSize: '0.875rem',
              fontWeight: 400,
              marginTop: '5px'
            }}
            variant="subtitle2">
            {listeners.discrepantToPrevious * 100}% change since last {listeners.comparedUnit}
          </Typography>
        </Stack>
        <Button
          sx={{ borderRadius: '7.5px', height: '40px' }}
          startIcon={(
            <SvgIcon fontSize="small">
              <PlusIcon />
            </SvgIcon>
          )}
          variant="contained">
          Add
        </Button>
      </Stack>


      <Button
        color="inherit"
        variant="outlined"
        size="small"
        sx={{ width: '100px', marginY: '25px' }}
        startIcon={(
          <SvgIcon fontSize="small">
            <ArrowPathIcon />
          </SvgIcon>
        )}
      >
        Sync
      </Button>
      <Chart
        height={350}
        options={{
          ...chartOptions,
          dataLabels: {
            enabled: false
          },
          stroke: {
            curve: 'smooth'
          },
        }}
        series={chartSeries}
        type="area"
        width="100%"
      />
    </Stack>
  );
};

OverviewListenerInPeriod.protoTypes = {
  listeners: PropTypes.array.isRequired,
  chartSeries: PropTypes.array.isRequired,
  sx: PropTypes.object
};
