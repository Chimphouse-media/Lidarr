/* eslint max-params: 0 */
import moment from 'moment';

function getStatusStyle(episodeNumber, downloading, startTime, isMonitored, percentOfTracks) {
  const currentTime = moment();

  if (percentOfTracks === 100) {
    return 'downloaded';
  }

  if (percentOfTracks > 0) {
    return 'partial';
  }

  if (downloading) {
    return 'downloading';
  }

  if (!isMonitored) {
    return 'unmonitored';
  }

  if (currentTime.isAfter(startTime)) {
    return 'missing';
  }

  return 'unreleased';
}

export default getStatusStyle;
