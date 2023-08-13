using UnityEngine;
using TMPro;
using BattleTank;

namespace BattleTank
{
	public class AchievementSystem : GenericSingleTon<AchievementSystem>
	{
		[SerializeField] private TextMeshProUGUI achievementTextTMP;
		[SerializeField] private GameObject achievementPanel;
		private float deactivationTime;
		private string achievementText;
		private void Start()
		{
			AchievementPanel(false);
			BulletService.Instance.onBulletFired += BulletFiringAchievement;
		}

		private void OnDisable()
		{
			BulletService.Instance.onBulletFired -= BulletFiringAchievement;
		}
		private void Update()
		{
			deactivationTime += Time.deltaTime;
			if (deactivationTime >= 5.0f)
			{
				AchievementPanel(false);
				deactivationTime = 0;
			}
		}
		private void BulletFiringAchievement(int _bulletCount)
		{
			AchievementPanel(true);
			switch (_bulletCount)
			{
				case 1:
				achievementText = "Fast Learner!";
				break;
				case 12:
				achievementText = "First Dozen!";
				break;
				case 15:
				achievementText = "Heavy Driver!";
				break;
				default:
				achievementText = "";
				AchievementPanel(false);
				break;
			}
			achievementTextTMP.text = achievementText;
		}

		private void AchievementPanel(bool _isActive)
		{
			achievementTextTMP.enabled = _isActive;
			achievementPanel.SetActive(_isActive);
		}
	}
}
